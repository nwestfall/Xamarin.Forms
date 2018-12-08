﻿using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

#if UITEST
using Xamarin.Forms.Core.UITests;
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Xamarin.Forms.Controls.Issues
{
#if UITEST
	[Category(UITestCategories.ManualReview)]
	[Explicit] // Marked explicit until we have a lane for CollectionView tests
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 4600, "[iOS] CollectionView crash with empty ObservableCollection", PlatformAffected.iOS)]
	public class Issue4600 : TestNavigationPage
	{
		protected override void Init()
		{
#if APP
			PushAsync(
				new GalleryPages.CollectionViewGalleries.ObservableCodeCollectionViewGallery(initialItems: 0));
#endif
		}

#if UITEST
		[Test]
		public void InitiallyEmptySourceDisplaysAddedItem()
		{
			RunningApp.WaitForElement("Insert");
			RunningApp.Tap("Insert");
			RunningApp.WaitForElement("Inserted");
		}
#endif
	}
}