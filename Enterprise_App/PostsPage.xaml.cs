using Enterprise_App.Data;
using Enterprise_App.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Enterprise_App
{
    public partial class PostsPage : ContentPage
    {
        public ObservableCollection<Post> PostsList { get; }

        DataRetriever _dr;
        public PostsPage()
        {
            InitializeComponent();

            Title = "Posts";
            PostsList = new ObservableCollection<Post>();
            PostsListView.ItemsSource = PostsList;

            PostsListView.ItemSelected += PostsListView_ItemSelected;

            _dr = new DataRetriever();

            PostsListView.IsVisible = false;
            Loader.IsVisible = true;

            LoadData();
            AddToolbarItem();

        }

        private void PostsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CommentsPage comments = new CommentsPage(e.SelectedItem as Post);
                Navigation.PushAsync(comments);
            }

            //clear selection
            PostsListView.SelectedItem = null;
        }

        private void AddToolbarItem()
        {
            ToolbarItem toolbarItem = new ToolbarItem("Refresh", null, () =>
            {
                LoadData();
            }, 0, 0);
            ToolbarItems.Add(toolbarItem);
        }

        private async Task LoadData()
        {
            PostsList.Clear();

            List<Post> posts = await _dr.GetPosts();

            Loader.IsRunning = false;
            Loader.IsVisible = false;
            PostsListView.IsVisible = true;

            foreach (Post p in posts)
            {
                PostsList.Add(p);
            }
        }
    }
}
