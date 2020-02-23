using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Piece_1:IAsset
    {
        List<char[,]> pieces;
        char[,] piece1 = new char[,] {
                                        { ' ', 'x', 'x' },
                                        { 'x', 'x', ' ' }
                                    };

        char[,] piece2 = new char[,] {
                                        { 'x', ' ' },
                                        { 'x', 'x' },
                                        { ' ', 'x' }
                                    };



        public Piece_1()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
