using Microsoft.Xna.Framework;

namespace Shared
{
    public class WK
    {
        public class Default
        {
            public static readonly int FPS = 60;
        }

        public class Scene
        {
            public static readonly string MenuScene = "Menu";
            public static readonly string GameScene = "Escena_1";
        }

        public class Piece
        {
            public static readonly char[,] S = new char[,] {    { ' ', 's', 's' },
                                                                { 's', 's', ' ' }   };

            public static readonly char[,] Z = new char[,] {    { 'z', 'z', ' ' },
                                                                { ' ', 'z', 'z' }   };

            public static readonly char[,] T = new char[,] {    { 't', 't', 't' },
                                                                { ' ', 't', ' ' }   };

            public static readonly char[,] O = new char[,] {    { 'o', 'o' },
                                                                { 'o', 'o' }   };

            public static readonly char[,] I = new char[,] {    { 'i' },
                                                                { 'i' },
                                                                { 'i' },
                                                                { 'i' }   };

            public static readonly char[,] L = new char[,] {    { 'l', ' ' },
                                                                { 'l', ' ' },
                                                                { 'l', 'l' }   };

            public static readonly char[,] J = new char[,] {    { ' ', 'j' },
                                                                { ' ', 'j' },
                                                                { 'j', 'j' }   };
        }

        public class Grid
        {
            public static readonly char[,] MainGrid = new char[,]   {
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                                                                    { '|', '-', '-', '-', '-', '-', '-', '-', '-', '|' },
                                                                    };
        }


        public class Font
        {
            public static readonly string MyFont_PNG_130x28 = "MyFont_PNG_130x28";

            public static readonly char[,] Chars = new char[,]
            {
                { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                { ',', ':', ';', '?', '.', '!', ' ','\'','(',')','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
            };
        }

        public class Desktop
        {
            public const int Height = 220;
            public const int Width = 180;
        }

        public class iPhone
        {
            public class XS
            {
                public const int Height = 2436;
                public const int Width = 1125;
                public const int ppi = 458;
            }

            public class XS_Max
            {
                public const int Height = 2688;
                public const int Width = 1242;
                public const int ppi = 458;
            }

            public class XR
            {
                public const int Height = 1792;
                public const int Width = 828;
                public const int ppi = 326;
            }

            public class SE
            {
                public const int Height = 1136;
                public const int Width = 640;
                public const int ppi = 326;
            }

            public class _3G
            {
                public const int Height = 480;
                public const int Width = 320;
                public const int ppi = 165;
            }
        }
    }
}