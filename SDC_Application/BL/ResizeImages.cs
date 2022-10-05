using System;
using System.Drawing;
using System.IO;
namespace SDC_Application.BL
{
    public static class ResizeImages
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="onlyResizeIfWider"></param>
        /// <returns></returns>
        public static Image ResizeImage(Image image,int width,int height,bool onlyResizeIfWider)
        {

                Image NewImage = image.GetThumbnailImage(70, 70, null, IntPtr.Zero);

                return NewImage;
            }
        public static Image ResizeImagePerson(Image image, int width, int height, bool onlyResizeIfWider)
        {

            Image NewImage = image.GetThumbnailImage(152, 117, null, IntPtr.Zero);

            return NewImage;
        }
        
        }


}


