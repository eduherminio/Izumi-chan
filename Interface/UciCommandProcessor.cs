﻿using Engine;
using Engine.Board;
using Engine.Move;
using Engine.Search;

namespace Interface;

internal class UciCommandProcessor : CommandProcessor
{
    public UciCommandProcessor( ChessEngine chessEngine ) : base( chessEngine ) 
    {
        Console.WriteLine( $"id name {EngineCredentials.FullName}" );
        Console.WriteLine( $"id author {EngineCredentials.Author}" );
        Console.WriteLine( $"uciok" );
    }

    public override void ProcessCommand( string[] commandSplit )
    {
        switch (commandSplit[0])
        {
            case "ucinewgame":
                HandleNewGameCommand();
                break;
            case "isready":
                HandleIsReadyCommand();
                break;
            case "position":
                HandlePositionCommand( commandSplit[1..] );
                break;
            case "go":
                HandleGoCommand( commandSplit[1..] );
                break;
        }
    }

    private void HandleNewGameCommand()
    {
        MoveHistory.Reset();
        //TT reset
    }

    private void HandleIsReadyCommand()
    {
        Console.WriteLine( "readyok" );
    }

    private void HandlePositionCommand( string[] args )
    {
        string fen = BoardProvider.StartPosition;
        List<MoveData>? moves = null;

        if (args[0] != "startpos")
            fen = args[1] + ' ' + args[2] + ' ' + args[3] + ' ' + args[4] + ' ' + args[5] + ' ' + args[6];

        BoardData tempBoard = BoardProvider.Create(fen);

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "moves")
            {
                moves = new();
                continue;
            }

            if (moves != null)
            {
                MoveData newMove = new ( args[i], tempBoard );
                moves.Add( newMove );
                tempBoard.MakeMove( newMove );
            }
        }

        moves ??= new();

        _chessEngine.ChangePosition( fen, moves );
        _chessEngine.DrawBoard();
    }

    private void HandleGoCommand( string[] args )
    {
        int depth = 100;
        int wTime = int.MaxValue;
        int bTime = int.MaxValue;

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "depth":
                    depth = int.Parse( args[i + 1] );
                    break;
                case "wtime":
                    wTime = int.Parse( args[i + 1] );
                    break;
                case "btime":
                    bTime = int.Parse( args[i + 1] );
                    break;
                case "movetime":
                    wTime = int.Parse( args[i + 1] ) * TimeManager.TimeDivider;
                    bTime = int.Parse( args[i + 1] ) * TimeManager.TimeDivider;
                    break;
            }
        }

        Thread searchThread = new (SearchThread);
        searchThread.Start( new SearchData( depth, wTime, bTime ) );
    }

    private void SearchThread( object? data )
    {
        SearchData searchData = (SearchData)data!;
        MoveData bestMove = _chessEngine.FindBestMove(searchData.Depth, searchData.WhiteTime, searchData.BlackTime);
        Console.WriteLine( $"bestmove {bestMove}" );
    }

    private record struct SearchData(int Depth, int WhiteTime, int BlackTime );
}