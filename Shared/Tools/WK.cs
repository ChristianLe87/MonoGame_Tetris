namespace Shared
{
    public class WK
    {
        public class Piece
        {
            public static readonly char[,] S = new char[,] {    { ' ', 'p', 'p' },
                                                                { 'p', 'p', ' ' }   };

            public static readonly char[,] Z = new char[,] {    { 'p', 'p', ' ' },
                                                                { ' ', 'p', 'p' }   };

            public static readonly char[,] T = new char[,] {    { 'p', 'p', 'p' },
                                                                { ' ', 'p', ' ' }   };

            public static readonly char[,] O = new char[,] {    { 'p', 'p' },
                                                                { 'p', 'p' }   };

            public static readonly char[,] I = new char[,] {    { 'p' },
                                                                { 'p' },
                                                                { 'p' },
                                                                { 'p' }   };

            public static readonly char[,] L = new char[,] {    { 'p', ' ' },
                                                                { 'p', ' ' },
                                                                { 'p', 'p' }   };

            public static readonly char[,] J = new char[,] {    { ' ', 'p' },
                                                                { ' ', 'p' },
                                                                { 'p', 'p' }   };
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