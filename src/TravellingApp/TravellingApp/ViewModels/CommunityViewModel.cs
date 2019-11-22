using System;
using System.Collections.ObjectModel;
using TravellingApp.Models;
using TravellingApp.Services;
using Xamarin.Forms;

namespace TravellingApp.ViewModels
{
    public class CommunityViewModel : BindableObject
    {
        private ObservableCollection<Post> _posts;
        private Post _currentPost;
		private int _currentIndex;

        public CommunityViewModel()
        {
            LoadPosts();
        }

        public ObservableCollection<Post> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }

        public Post CurrentPost
        {
            get { return _currentPost; }
            set
            {
                _currentPost = value;
                OnPropertyChanged();
            }
        }

		public int CurrentIndex
		{
			get { return _currentIndex;  }
			set
			{
				_currentIndex = value;
				Console.WriteLine($"{Environment.NewLine}=========================> Setting Current Index to {_currentIndex}");
				OnPropertyChanged();
			}
		}

        private void LoadPosts()
        {
            var posts = MockPostService.Instance.GetCommunityPosts();
            Posts = new ObservableCollection<Post>(posts);
            CurrentPost = Posts[0];
        }
    }
}
