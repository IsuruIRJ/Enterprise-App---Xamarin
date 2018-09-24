using Enterprise_App.Data;
using Enterprise_App.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Enterprise_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentsPage : ContentPage
    {
        public ObservableCollection<Comment> CommentsList { get; }

        DataRetriever _dr;
        public CommentsPage()
        {
            InitializeComponent();
        }

        public CommentsPage(Post post) : this()
        {
            Title = "Comments";
            CommentsList = new ObservableCollection<Comment>();
            CommentsListView.ItemsSource = CommentsList;

            CommentsListView.ItemSelected += CommentsListView_ItemSelected;

            _dr = new DataRetriever();

            CommentsListView.IsVisible = false;
            Loader.IsVisible = true;

            LoadData(post.Id);
            AddToolbarItem(post.UserId);
        }

        private void CommentsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Comment cmt = e.SelectedItem as Comment;
                string urlToLaunch = "mailto:" + cmt.Email;
                Device.OpenUri(new System.Uri(urlToLaunch));
            }

            //clear selection
            CommentsListView.SelectedItem = null;
        }

        private void UserIcon_Clicked(int userId)
        {
            User user = _dr.GetUser(userId);

            ProfilePage profile = new ProfilePage(user);
            Navigation.PushAsync(profile);
        }

        private void AddToolbarItem(int userId)
        {

            ToolbarItem toolbarItem = new ToolbarItem(Icon, "/Resources/drawable/user1.png", () =>
            {
                UserIcon_Clicked(userId);
            }, 0, 0);
            ToolbarItems.Add(toolbarItem);
        }

        private async void LoadData(int id)
        {
            CommentsList.Clear();

            List<Comment> comments = await _dr.GetComments(id);

            Loader.IsRunning = false;
            Loader.IsVisible = false;
            CommentsListView.IsVisible = true;

            foreach (Comment c in comments)
            {
                CommentsList.Add(c);
            }

        }
    }
}