using System;

interface IHitBox
{
    int x;
    int y;
    int width;
    int height;
    bool IsHit(IHitBox other);
}


