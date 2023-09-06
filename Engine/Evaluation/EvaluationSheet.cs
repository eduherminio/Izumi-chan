﻿using System;

namespace Engine.Evaluation
{
    public static class EvaluationSheet
    {
        public const ushort BishopPairMidgameBonus = 21;
        public const ushort BishopPairEndgameBonus = 24;

        //per pawn
        public const int DoublePawnMidgamePenalty = -10;
        public const int DoublePawnEndgamePenalty = -16;

        public static ReadOnlySpan<byte> PiecePhase => [ 0, 1, 1, 2, 4, 0 ];

        public static ReadOnlySpan<ushort> PieceValues => [102, 110, 392, 244, 412, 259, 569, 463, 1250, 816, 10000, 10000];


        public static ReadOnlySpan<sbyte> PstsTable => [
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            -44, 2, -7, -3, -26, 0, -38, 2,
            -18, -5, 19, -13, 43, -19, -16, -24,
            -40, -11, -13, -8, -9, -20, -14, -13,
            2, -20, -10, -15, 31, -19, -16, -25,
            -45, -1, -5, -6, -10, -23, 11, -30,
            10, -29, 2, -24, 3, -16, -47, -16,
            -18, 16, 8, 9, 5, -4, 20, -18,
            33, -26, 18, -13, 11, -2, -24, -2,
            -16, 75, 8, 75, 32, 56, 30, 41,
            41, 29, 75, 24, 21, 54, -1, 58,
            100, 127, 93, 127, 62, 117, 80, 92,
            127, 86, 47, 116, 30, 127, -11, 127,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            -62, -52, -24, -37, -42, -19, -33, -10,
            -17, -27, -11, -17, -26, -37, -76, -42,
            -34, -29, -26, -12, 0, -14, 6, 1,
            11, -6, 15, -11, 3, -19, -1, -26,
            -21, -21, 4, -1, 25, -5, 21, 13,
            35, 9, 21, -3, 28, -11, -19, -31,
            -7, -10, 9, -1, 31, 14, 25, 19,
            34, 22, 38, 8, 22, -5, -13, -11,
            23, -16, 22, 13, 32, 19, 75, 17,
            41, 18, 70, 4, 12, 9, 38, -18,
            22, -22, 63, -20, 63, 3, 74, 7,
            127, -18, 115, -10, 92, -27, 33, -27,
            -13, -35, 4, -18, 62, -15, 64, -13,
            41, -20, 94, -31, 34, -31, 33, -48,
            -128, -47, -32, -36, -50, -13, -59, -18,
            62, -40, -123, -23, -84, -27, -128, -83,
            -8, -31, -17, -15, -17, -30, -21, -11,
            -31, -12, -30, -19, -15, -23, -27, -21,
            4, -21, 22, -27, 12, -15, -5, 0,
            -1, 2, 17, -9, 32, -17, 14, -38,
            10, -18, 14, -4, 12, 5, 12, 7,
            10, 13, 15, 0, 12, -15, 8, -22,
            -18, -10, 9, 1, 5, 11, 31, 6,
            30, 7, 9, 10, 6, -4, -24, -17,
            -12, -1, 1, 11, 20, 8, 32, 12,
            25, 14, 20, 1, 2, 0, -3, -12,
            -6, 0, 22, -3, 21, 6, 50, -1,
            43, -4, 82, -2, 36, 1, 47, -20,
            -17, -14, 35, -12, 0, -1, 4, -6,
            23, -4, 13, -5, 33, -8, -21, -25,
            -33, -10, -8, -15, -31, -16, -20, -7,
            -56, -4, -102, 9, -95, -11, -45, -6,
            -10, -12, -7, 0, 10, -1, 14, -1,
            18, -13, -3, -17, -43, 13, -22, -25,
            -46, 2, -17, -1, -5, -1, 2, -3,
            1, -9, -2, -8, -5, -7, -61, 1,
            -23, -8, -10, -2, 2, -5, 4, -6,
            4, -5, -13, -8, 14, -19, -19, -14,
            -8, -1, -3, -1, 3, 2, 5, 3,
            13, -4, -3, -6, -1, -11, 0, -15,
            4, -2, 3, 5, 42, -4, 42, -2,
            32, -4, 39, -8, 32, -13, 53, -25,
            25, 1, 46, -3, 36, 3, 57, -3,
            64, -8, 83, -15, 77, -14, 66, -18,
            31, 3, 25, 11, 63, 2, 91, -3,
            66, -6, 83, -9, 45, -6, 75, -18,
            39, 9, 89, -6, 87, -7, 78, -3,
            100, -12, 126, -20, 57, -5, 80, -9,
            -11, -17, -28, -18, -15, -30, 2, -53,
            -23, -12, -44, -15, -54, -13, -46, -17,
            -30, -2, -4, -5, 5, -23, -4, 3,
            6, -21, 21, -50, 26, -75, 7, -60,
            -21, -8, 1, -19, -9, 21, -5, 5,
            -4, 18, 2, 13, 2, 6, -16, -9,
            -16, -11, -8, 9, -12, 14, -7, 52,
            0, 27, -11, 31, 1, 24, -15, -4,
            -28, -4, -25, 24, -8, 32, 3, 30,
            -15, 66, 3, 49, -18, 47, 14, 1,
            -15, -9, -8, 7, -23, 45, 25, 21,
            20, 55, 91, 1, 66, -20, 58, -37,
            -24, 9, -28, 16, -26, 42, -40, 78,
            -37, 85, 38, 29, 13, 28, 42, -31,
            -64, 22, -27, 23, -10, 32, 43, 7,
            62, 1, -2, 25, -61, 40, -24, 24,
            -59, -28, 20, -37, -7, -19, -86, -3,
            -20, -33, -65, -8, 12, -30, 0, -48,
            14, -35, -20, -8, -37, 5, -108, 26,
            -87, 26, -50, 15, -3, -3, -2, -19,
            -20, -31, -20, -5, -69, 14, -92, 28,
            -95, 31, -77, 26, -29, 8, -42, -6,
            4, -35, 5, -5, -12, 11, -77, 28,
            -77, 32, -60, 27, -39, 14, -59, 0,
            4, -24, -7, -2, 25, 6, -3, 18,
            -24, 19, -9, 24, 27, 15, -56, 9,
            27, -14, 89, -6, 16, 9, 6, 9,
            19, 13, 49, 16, 55, 19, 17, 8,
            22, -19, 51, -3, 60, -9, 33, 3,
            77, -2, 51, 14, 20, 16, -6, 8,
            83, -55, 40, -23, 80, -31, 80, -25,
            91, -24, 77, -11, 58, -8, 56, -38
        ];
    }
}
