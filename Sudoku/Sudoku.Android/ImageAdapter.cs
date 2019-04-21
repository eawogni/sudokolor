using Android.Views;
using Android.Widget;
using Android.Content;

namespace Sudoku.Droid
{
    /// <summary>
    /// Adaptaterpour Grid View
    /// </summary>
    class ImageAdapter : BaseAdapter
    {
        private int[] tableauImage; //Tableau d'images
        private Context context; // Context
        private int wScreen; //Largeur de l'écran

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context"></param>
        /// <param name="tabImage"></param>
        /// <param name="width"></param>
        public ImageAdapter(Context context, int[] tabImage, int width)
        {
            this.tableauImage = tabImage;
            this.context = context;
            this.wScreen = (int)(width/9.8);
        }

        /// <summary>
        /// Compteur
        /// </summary>
        public override int Count
        {
            get { return this.tableauImage.Length; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        /// <summary>
        /// Getter de vue
        /// </summary>
        /// <param name="position"></param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView imageView;

            if (convertView == null)
            {
                imageView = new ImageView(context);
                imageView.LayoutParameters = new GridView.LayoutParams(wScreen, wScreen); //Indique la quantité d'espace supplémentaire dans LinearLayout qui sera allouée à l'imageView.
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
            }
            else
            {
                imageView = (ImageView)convertView;
            }

            imageView.SetImageResource(this.tableauImage[position]);
            return imageView;
        }
    }
}