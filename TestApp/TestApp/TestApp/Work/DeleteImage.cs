using System;
using Android.Views;
using Android.Widget;

namespace TestApp
{
	public class DeleteImage
	{
		public DeleteImage()
		{
		}
	public void loopLayout(ViewGroup viewGroup)
		{

			for (int i = 0; i < viewGroup.ChildCount; i++)
			{
				var childView = viewGroup.GetChildAt(i);

				if (childView is ViewGroup)
				{
					for (int j = 0; j < ((ViewGroup)childView).ChildCount; j++)
					{
						var childView2 = ((ViewGroup)childView).GetChildAt(j);
						setImageSRC(childView2);
					}
				}

			}
		}
		public void setImageSRC(View childview)
		{

			if (childview is ViewGroup)
				loopLayout((ViewGroup)childview);

			if (childview is ImageView)
			{
				

			}

		}

	}
}
