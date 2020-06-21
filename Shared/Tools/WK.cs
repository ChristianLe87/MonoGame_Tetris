using Microsoft.Xna.Framework;

namespace Shared
{
    public class WK
    {
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
            public const string Arial_10 = "Arial_10";
        }

        public class Desktop
        {
            public const int Height = 220;
            public const int Width = 160;
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