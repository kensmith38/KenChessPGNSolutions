using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    public static class UtilitiesLegalUCIMoves
    {
        /// <summary>
        /// Get list of all legal moves (UCI format) for active player filtered by piece type.
        /// For pieceTypeFilter: Enter K-King Q-Queen etc or * for all piece types. (Use uppercase for both white/black active player)
        /// </summary>
        public static List<string> getAllLegalUciMovesForActivePlayer(ChessBoard chessBoard, char pieceTypeFilter)
        {
            List<string> listLegalUicMoves = new List<string>();

            for (int fileIndex = 0; fileIndex < 8; fileIndex++)
            {
                for (int rankIndex = 0; rankIndex < 8; rankIndex++)
                {
                    ChessSquare chessSquare = chessBoard.ChessBoardSquares[fileIndex, rankIndex];
                    if (chessSquare.PieceOnSquare.PieceType == PieceType.None)
                    {
                        continue;
                    }
                    if (chessSquare.PieceOnSquare.PieceColor != chessBoard.ActivePlayer)
                    {
                        continue;
                    }
                    if (chessSquare.PieceOnSquare.PieceType == PieceType.King)
                    {
                        if ((pieceTypeFilter == '*') || (pieceTypeFilter == 'K'))
                        {
                            listLegalUicMoves.AddRange(getAllLegalUciMovesForKingNonCastlingOnSpecificSquare(chessBoard, chessSquare));
                        }
                    }
                    if (chessSquare.PieceOnSquare.PieceType == PieceType.King)
                    {
                        if ((pieceTypeFilter == '*') || (pieceTypeFilter == 'K'))
                        {
                            listLegalUicMoves.AddRange(getAllLegalUciMovesForCastlingByActivePlayer(chessBoard, chessSquare));
                        }
                    }
                    if (chessSquare.PieceOnSquare.PieceType == PieceType.Knight)
                    {
                        if ((pieceTypeFilter == '*') || (pieceTypeFilter == 'N'))
                        {
                            listLegalUicMoves.AddRange(getAllLegalUciMovesForKnightOnSpecificSquare(chessBoard, chessSquare));
                        }
                    }
                    if (chessSquare.PieceOnSquare.PieceType == PieceType.Rook)
                    {
                        if ((pieceTypeFilter == '*') || (pieceTypeFilter == 'R'))
                        {
                            listLegalUicMoves.AddRange(getAllLegalUciMovesForRookOnSpecificSquare(chessBoard, chessSquare));
                        }
                    }
                    if (chessSquare.PieceOnSquare.PieceType == PieceType.Bishop)
                    {
                        if ((pieceTypeFilter == '*') || (pieceTypeFilter == 'B'))
                        {
                            listLegalUicMoves.AddRange(getAllLegalUciMovesForBishopOnSpecificSquare(chessBoard, chessSquare));
                        }
                    }
                    if (chessSquare.PieceOnSquare.PieceType == PieceType.Queen)
                    {
                        if ((pieceTypeFilter == '*') || (pieceTypeFilter == 'Q'))
                        {
                            listLegalUicMoves.AddRange(getAllLegalUciMovesForQueenOnSpecificSquare(chessBoard, chessSquare));
                        }
                    }
                    if ((chessBoard.ActivePlayer == 'w') && (chessSquare.PieceOnSquare.PieceType == PieceType.Pawn))
                    {
                        if ((pieceTypeFilter == '*') || (pieceTypeFilter == 'P'))
                        {
                            listLegalUicMoves.AddRange(getAllLegalUciMovesForWhitePawnOnSpecificSquare(chessBoard, chessSquare));
                        }
                    }
                    if ((chessBoard.ActivePlayer == 'b') && (chessSquare.PieceOnSquare.PieceType == PieceType.Pawn))
                    {
                        if ((pieceTypeFilter == '*') || (pieceTypeFilter == 'P'))
                        {
                            listLegalUicMoves.AddRange(getAllLegalUciMovesForBlackPawnOnSpecificSquare(chessBoard, chessSquare));
                        }
                    }
                }
            }
            return listLegalUicMoves;
        }
        /// <summary>
        /// Gets all legal UCI moves for knight on specific square.
        /// </summary>
        public static List<string> getAllLegalUciMovesForKnightOnSpecificSquare(ChessBoard chessBoard, ChessSquare startingChessSquare)
        {
            List<string> listUciMoves = new List<string>();
            ChessSquare candidateDestinationChessSquare;
            KnightJumpDirection knightJumpDirection = KnightJumpDirection.None;

            for (int iii = 0; iii < 8; iii++)
            {
                if (iii == 0) { knightJumpDirection = KnightJumpDirection.North2East1; }
                if (iii == 1) { knightJumpDirection = KnightJumpDirection.North2West1; }
                if (iii == 2) { knightJumpDirection = KnightJumpDirection.East2North1; }
                if (iii == 3) { knightJumpDirection = KnightJumpDirection.East2South1; }
                if (iii == 4) { knightJumpDirection = KnightJumpDirection.South2East1; }
                if (iii == 5) { knightJumpDirection = KnightJumpDirection.South2West1; }
                if (iii == 6) { knightJumpDirection = KnightJumpDirection.West2North1; }
                if (iii == 7) { knightJumpDirection = KnightJumpDirection.West2South1; }

                candidateDestinationChessSquare = chessBoard.getKnightJumpSquare(startingChessSquare, knightJumpDirection);

                if (candidateDestinationChessSquare != null)
                {
                    if ((candidateDestinationChessSquare.PieceOnSquare.PieceType == PieceType.None) ||
                        (candidateDestinationChessSquare.PieceOnSquare.PieceColor != chessBoard.ActivePlayer))
                    {
                        string possibleUciMove = startingChessSquare.UciSquareName + candidateDestinationChessSquare.UciSquareName;
                        // make sure we dont expose the king to check by moving a pinned piece!
                        ChessBoard tempChessBoard = chessBoard.clone();
                        // Remember, this toggles the activePlayer
                        tempChessBoard.PerformUciMove(possibleUciMove);
                        // Tricky! Toggle the active player so isActivePlayerInCheck considers correct target king!
                        tempChessBoard.toggleActivePlayer();
                        if (!UtilitiesActivePlayerInCheck.isActivePlayerInCheck(tempChessBoard))
                        {
                            listUciMoves.Add(possibleUciMove);
                        }
                    }
                }
            }
            return listUciMoves;
        }
        /// <summary>
        /// Gets all legal UCI moves for castling by active player.
        /// </summary>
        public static List<string> getAllLegalUciMovesForCastlingByActivePlayer(ChessBoard chessBoard, ChessSquare activePlayerKingSquare)
        {
            List<string> listUciMoves = new List<string>();
            if ((activePlayerKingSquare.UciSquareName.Equals("e1")) && (activePlayerKingSquare.PieceOnSquare.PieceColor == 'w'))
            {
                // make sure castling is even allowed 
                if (chessBoard.WhiteCanCastleLong)
                {
                    // now examine more specific rules
                    ChessSquare[] squaresBetweenKingAndRook = new ChessSquare[]
                        { chessBoard.getChessSquareWithUciName("b1"), chessBoard.getChessSquareWithUciName("c1"), chessBoard.getChessSquareWithUciName("d1") };
                    bool isCastlingAllowed = isCastlingRulesSatisfied(chessBoard, activePlayerKingSquare, squaresBetweenKingAndRook, "e1c1");
                    if (isCastlingAllowed)
                    {
                        listUciMoves.Add("e1c1");
                    }
                }
            }
            if ((activePlayerKingSquare.UciSquareName.Equals("e1")) && (activePlayerKingSquare.PieceOnSquare.PieceColor == 'w'))
            {
                // make sure castling is even allowed 
                if (chessBoard.WhiteCanCastleShort)
                {
                    // now examine more specific rules
                    ChessSquare[] squaresBetweenKingAndRook = new ChessSquare[]
                        { chessBoard.getChessSquareWithUciName("f1"), chessBoard.getChessSquareWithUciName("g1") };
                    bool isCastlingAllowed = isCastlingRulesSatisfied(chessBoard, activePlayerKingSquare, squaresBetweenKingAndRook, "e1g1");
                    if (isCastlingAllowed)
                    {
                        listUciMoves.Add("e1g1");
                    }
                }
            }
            if ((activePlayerKingSquare.UciSquareName.Equals("e8")) && (activePlayerKingSquare.PieceOnSquare.PieceColor == 'b'))
            {
                // make sure castling is even allowed 
                if (chessBoard.BlackCanCastleLong)
                {
                    // now examine more specific rules
                    ChessSquare[] squaresBetweenKingAndRook = new ChessSquare[]
                        { chessBoard.getChessSquareWithUciName("b8"), chessBoard.getChessSquareWithUciName("c8"), chessBoard.getChessSquareWithUciName("d8") };
                    bool isCastlingAllowed = isCastlingRulesSatisfied(chessBoard, activePlayerKingSquare, squaresBetweenKingAndRook, "e8c8");
                    if (isCastlingAllowed)
                    {
                        listUciMoves.Add("e8c8");
                    }
                }
            }
            if ((activePlayerKingSquare.UciSquareName.Equals("e8")) && (activePlayerKingSquare.PieceOnSquare.PieceColor == 'b'))
            {
                // make sure castling is even allowed 
                if (chessBoard.BlackCanCastleShort)
                {
                    // now examine more specific rules
                    ChessSquare[] squaresBetweenKingAndRook = new ChessSquare[]
                        { chessBoard.getChessSquareWithUciName("f8"), chessBoard.getChessSquareWithUciName("g8") };
                    bool isCastlingAllowed = isCastlingRulesSatisfied(chessBoard, activePlayerKingSquare, squaresBetweenKingAndRook, "e8g8");
                    if (isCastlingAllowed)
                    {
                        listUciMoves.Add("e8g8");
                    }
                }
            }
            return listUciMoves;
        }
        /// <summary>
        /// This method is called after confirming that castling rights still exist for white long castling. 
        /// The Castling Rights (as stored in FEN and thus in our ChessBoard properties) specify whether both sides are principally able to castle king- or queen side,
        /// now or later during the game - whether the involved pieces have already moved or in case of the rooks, were captured. 
        /// Castling rights do not specify, whether castling is actually possible, but are a pre-condition for both wing castlings.
        /// Thus castling might still be illegal at this point for 3 reasons:
        /// 1. no pieces between king and rook
        /// 2. king is not in check
        /// 3. king does not pass over attacked square
        /// </summary>
        private static bool isCastlingRulesSatisfied(ChessBoard chessBoard, ChessSquare activePlayerKingSquare,
            ChessSquare[] squaresBetweenKingAndRook, string castlingUciMove)
        {
            // Tricky! must make sure
            // 1. no pieces between king and rook
            // 2. king is not in check
            // 3. king does not pass over attacked square
            bool castlingAllowed = true;
            // 1. ensure no pieces between king and rook
            foreach (ChessSquare nextSquare in squaresBetweenKingAndRook)
            {
                if (nextSquare.PieceOnSquare.PieceType != PieceType.None)
                {
                    castlingAllowed = false;
                }
            }
            // 2. ensure king is not in check
            if ((castlingAllowed) && (!UtilitiesActivePlayerInCheck.isActivePlayerInCheck(chessBoard)))
            {
                // make sure king does not pass over an attacked square
                foreach (ChessSquare nextSquare in squaresBetweenKingAndRook)
                {
                    ChessBoard tempChessBoard = chessBoard.clone();
                    tempChessBoard.getChessSquareWithUciName(nextSquare.UciSquareName).PieceOnSquare = activePlayerKingSquare.PieceOnSquare;
                    tempChessBoard.getChessSquareWithUciName(castlingUciMove.Substring(0, 2)).PieceOnSquare.PieceType = PieceType.None;
                    if (UtilitiesActivePlayerInCheck.isActivePlayerInCheck(tempChessBoard))
                    {
                        castlingAllowed = false;
                        break;
                    }
                }
            }
            // 3. ensure king does not pass over attacked square
            if (castlingAllowed)
            {
                // make sure king does not end up on an attacked square
                ChessBoard tempChessBoard = chessBoard.clone();
                // Remember, this toggles the activePlayer
                tempChessBoard.PerformUciMove(castlingUciMove);
                // Tricky! Toggle the active player so isActivePlayerInCheck considers correct target king!
                tempChessBoard.toggleActivePlayer();
                if (UtilitiesActivePlayerInCheck.isActivePlayerInCheck(tempChessBoard))
                {
                    castlingAllowed = false;
                }
            }
            return castlingAllowed;
        }

        /// <summary>
        /// Gets all legal UCI moves for king (non-castling) on specific square.
        /// </summary>
        public static List<string> getAllLegalUciMovesForKingNonCastlingOnSpecificSquare(ChessBoard chessBoard, ChessSquare startingChessSquare)
        {
            List<string> listUciMoves = new List<string>();
            ChessSquare candidateDestinationChessSquare;
            Direction direction = Direction.None;

            for (int iii = 0; iii < 8; iii++)
            {
                if (iii == 0) { direction = Direction.North; }
                if (iii == 1) { direction = Direction.South; }
                if (iii == 2) { direction = Direction.East; }
                if (iii == 3) { direction = Direction.West; }
                if (iii == 4) { direction = Direction.NorthEast; }
                if (iii == 5) { direction = Direction.NorthWest; }
                if (iii == 6) { direction = Direction.SouthEast; }
                if (iii == 7) { direction = Direction.SouthWest; }

                candidateDestinationChessSquare = chessBoard.getAdjacentSquare(startingChessSquare, direction);

                if (candidateDestinationChessSquare != null)
                {
                    if ((candidateDestinationChessSquare.PieceOnSquare.PieceType == PieceType.None) ||
                        (candidateDestinationChessSquare.PieceOnSquare.PieceColor != chessBoard.ActivePlayer))
                    {
                        string possibleUciMove = startingChessSquare.UciSquareName + candidateDestinationChessSquare.UciSquareName;
                        // make sure we dont expose the king to check by moving a pinned piece!
                        ChessBoard tempChessBoard = chessBoard.clone();
                        // Remember, this toggles the activePlayer
                        tempChessBoard.PerformUciMove(possibleUciMove);
                        // Tricky! Toggle the active player so isActivePlayerInCheck considers correct target king!
                        tempChessBoard.toggleActivePlayer();
                        if (!UtilitiesActivePlayerInCheck.isActivePlayerInCheck(tempChessBoard))
                        {
                            listUciMoves.Add(possibleUciMove);
                        }
                    }

                }
            }
            return listUciMoves;
        }
        /// <summary>
        /// Gets all legal UCI moves for queen on specific square.
        /// </summary>
        public static List<string> getAllLegalUciMovesForQueenOnSpecificSquare(ChessBoard chessBoard, ChessSquare startingChessSquare)
        {
            List<string> listUciMoves = new List<string>();
            List<string> listRookUciMoves = getAllLegalUciMovesForRookOnSpecificSquare(chessBoard, startingChessSquare);
            List<string> listBishopUciMoves = getAllLegalUciMovesForBishopOnSpecificSquare(chessBoard, startingChessSquare);
            listUciMoves.AddRange(listRookUciMoves);
            listUciMoves.AddRange(listBishopUciMoves);
            return listUciMoves;
        }
        /// <summary>
        /// Gets all legal UCI moves for rook on specific square.
        /// </summary>
        public static List<string> getAllLegalUciMovesForRookOnSpecificSquare(ChessBoard chessBoard, ChessSquare startingChessSquare)
        {
            List<string> listUciMoves = new List<string>();
            ChessSquare candidateDestinationChessSquare;
            Direction direction = Direction.None;

            for (int iii = 0; iii < 4; iii++)
            {
                if (iii == 0) { direction = Direction.North; }
                if (iii == 1) { direction = Direction.South; }
                if (iii == 2) { direction = Direction.East; }
                if (iii == 3) { direction = Direction.West; }
                candidateDestinationChessSquare = chessBoard.getAdjacentSquare(startingChessSquare, direction);

                while (candidateDestinationChessSquare != null)
                {
                    if ((candidateDestinationChessSquare.PieceOnSquare.PieceType == PieceType.None) ||
                        (candidateDestinationChessSquare.PieceOnSquare.PieceColor != chessBoard.ActivePlayer))
                    {
                        string possibleUciMove = startingChessSquare.UciSquareName + candidateDestinationChessSquare.UciSquareName;
                        // make sure we dont expose the king to check by moving a pinned piece!
                        ChessBoard tempChessBoard = chessBoard.clone();
                        // Remember, this toggles the activePlayer
                        tempChessBoard.PerformUciMove(possibleUciMove);
                        // Tricky! Toggle the active player so isActivePlayerInCheck considers correct target king!
                        tempChessBoard.toggleActivePlayer();
                        if (!UtilitiesActivePlayerInCheck.isActivePlayerInCheck(tempChessBoard))
                        {
                            listUciMoves.Add(possibleUciMove);
                        }
                    }
                    if (candidateDestinationChessSquare.PieceOnSquare.PieceType != PieceType.None)
                    {
                        break;
                    }
                    candidateDestinationChessSquare = chessBoard.getAdjacentSquare(candidateDestinationChessSquare, direction);
                }
            }
            return listUciMoves;
        }
        /// <summary>
        /// Gets all legal UCI moves for bishop on specific square.
        /// </summary>
        public static List<string> getAllLegalUciMovesForBishopOnSpecificSquare(ChessBoard chessBoard, ChessSquare startingChessSquare)
        {
            List<string> listUciMoves = new List<string>();
            ChessSquare candidateDestinationChessSquare;
            Direction direction = Direction.None;

            for (int iii = 0; iii < 4; iii++)
            {
                if (iii == 0) { direction = Direction.NorthEast; }
                if (iii == 1) { direction = Direction.NorthWest; }
                if (iii == 2) { direction = Direction.SouthEast; }
                if (iii == 3) { direction = Direction.SouthWest; }
                candidateDestinationChessSquare = chessBoard.getAdjacentSquare(startingChessSquare, direction);

                while (candidateDestinationChessSquare != null)
                {
                    if ((candidateDestinationChessSquare.PieceOnSquare.PieceType == PieceType.None) ||
                        (candidateDestinationChessSquare.PieceOnSquare.PieceColor != chessBoard.ActivePlayer))
                    {
                        string possibleUciMove = startingChessSquare.UciSquareName + candidateDestinationChessSquare.UciSquareName;
                        // make sure we dont expose the king to check by moving a pinned piece!
                        ChessBoard tempChessBoard = chessBoard.clone();
                        // Remember, this toggles the activePlayer
                        tempChessBoard.PerformUciMove(possibleUciMove);
                        // Tricky! Toggle the active player so isActivePlayerInCheck considers correct target king!
                        tempChessBoard.toggleActivePlayer();
                        if (!UtilitiesActivePlayerInCheck.isActivePlayerInCheck(tempChessBoard))
                        {
                            listUciMoves.Add(possibleUciMove);
                        }
                    }
                    if (candidateDestinationChessSquare.PieceOnSquare.PieceType != PieceType.None)
                    {
                        break;
                    }
                    candidateDestinationChessSquare = chessBoard.getAdjacentSquare(candidateDestinationChessSquare, direction);
                }
            }
            return listUciMoves;
        }
        /// <summary>
        /// Gets all legal UCI moves for white pawn on specific square.
        /// Considers: move/capture/promotion/enpassant
        /// </summary>
        public static List<string> getAllLegalUciMovesForWhitePawnOnSpecificSquare(ChessBoard chessBoard, ChessSquare startingChessSquare)
        {
            List<string> listUciMoves = new List<string>();
            List<string> listPossibleUciMoves = new List<string>();

            ChessSquare squareAdjacentNorth = chessBoard.getAdjacentSquare(startingChessSquare, Direction.North);
            ChessSquare squareAdjacentSouth = chessBoard.getAdjacentSquare(startingChessSquare, Direction.South);
            ChessSquare squareAdjacentNorthEast = chessBoard.getAdjacentSquare(startingChessSquare, Direction.NorthEast);
            ChessSquare squareAdjacentNorthWest = chessBoard.getAdjacentSquare(startingChessSquare, Direction.NorthWest);
            ChessSquare squareAdjacentSouthEast = chessBoard.getAdjacentSquare(startingChessSquare, Direction.SouthEast);
            ChessSquare squareAdjacentSouthWest = chessBoard.getAdjacentSquare(startingChessSquare, Direction.SouthWest);
            ChessSquare squareTwoSquaresNorth = chessBoard.getAdjacentSquare(squareAdjacentNorth, Direction.North);
            ChessSquare squareTwoSquaresSouth = chessBoard.getAdjacentSquare(squareAdjacentSouth, Direction.South);

            // white 
            if (startingChessSquare.PieceOnSquare.PieceColor == 'w')
            {
                // consider move forward 1
                if (squareAdjacentNorth.PieceOnSquare.PieceType == PieceType.None)
                {
                    //listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentNorth.UciSquareName);
                    if (squareAdjacentNorth.UciSquareName.EndsWith("8"))
                    {
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentNorth.UciSquareName + "Q");
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentNorth.UciSquareName + "R");
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentNorth.UciSquareName + "B");
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentNorth.UciSquareName + "N");
                    }
                    else
                    {
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentNorth.UciSquareName);
                    }
                }
                // consider move forward 2
                if (startingChessSquare.UciSquareName.EndsWith("2"))
                {
                    if ((squareAdjacentNorth.PieceOnSquare.PieceType == PieceType.None) &&
                        (squareTwoSquaresNorth.PieceOnSquare.PieceType == PieceType.None))
                    {
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareTwoSquaresNorth.UciSquareName);
                    }
                }
                // consider enpassant capture
                if (chessBoard.EnPassantTargetSquare != null)
                {
                    ChessSquare epSquare = chessBoard.EnPassantTargetSquare;
                    ChessSquare southwestSquare = chessBoard.getAdjacentSquare(epSquare, Direction.SouthWest);
                    ChessSquare southeastSquare = chessBoard.getAdjacentSquare(epSquare, Direction.SouthEast);

                    if ((southwestSquare != null) && (startingChessSquare == southwestSquare))
                    {
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + epSquare.UciSquareName);

                    }
                    if ((southeastSquare != null) && (startingChessSquare == southeastSquare))
                    {
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + epSquare.UciSquareName);
                    }
                }
                // consider capture
                if ((squareAdjacentNorthEast != null) &&
                    (squareAdjacentNorthEast.PieceOnSquare.PieceType != PieceType.None) &&
                    (squareAdjacentNorthEast.PieceOnSquare.PieceColor == 'b'))
                {
                    listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentNorthEast.UciSquareName);
                }
                if ((squareAdjacentNorthWest != null) &&
                    (squareAdjacentNorthWest.PieceOnSquare.PieceType != PieceType.None) &&
                    (squareAdjacentNorthWest.PieceOnSquare.PieceColor == 'b'))
                {
                    listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentNorthWest.UciSquareName);
                }
            }
            //
            foreach (string possibleUciMove in listPossibleUciMoves)
            {
                // make sure we dont expose the king to check by moving a pinned piece!
                ChessBoard tempChessBoard = chessBoard.clone();
                // Remember, this toggles the activePlayer
                tempChessBoard.PerformUciMove(possibleUciMove);
                // Tricky! Toggle the active player so isActivePlayerInCheck considers correct target king!
                tempChessBoard.toggleActivePlayer();
                if (!UtilitiesActivePlayerInCheck.                  isActivePlayerInCheck(tempChessBoard))
                {
                    listUciMoves.Add(possibleUciMove);
                }
            }
            return listUciMoves;
        }
        /// <summary>
        /// Gets all legal UCI moves for black pawn on specific square.
        /// Considers: move/capture/promotion/enpassant
        /// </summary>
        public static List<string> getAllLegalUciMovesForBlackPawnOnSpecificSquare(ChessBoard chessBoard, ChessSquare startingChessSquare)
        {
            List<string> listUciMoves = new List<string>();
            List<string> listPossibleUciMoves = new List<string>();

            ChessSquare squareAdjacentNorth = chessBoard.getAdjacentSquare(startingChessSquare, Direction.North);
            ChessSquare squareAdjacentSouth = chessBoard.getAdjacentSquare(startingChessSquare, Direction.South);
            ChessSquare squareAdjacentNorthEast = chessBoard.getAdjacentSquare(startingChessSquare, Direction.NorthEast);
            ChessSquare squareAdjacentNorthWest = chessBoard.getAdjacentSquare(startingChessSquare, Direction.NorthWest);
            ChessSquare squareAdjacentSouthEast = chessBoard.getAdjacentSquare(startingChessSquare, Direction.SouthEast);
            ChessSquare squareAdjacentSouthWest = chessBoard.getAdjacentSquare(startingChessSquare, Direction.SouthWest);
            ChessSquare squareTwoSquaresNorth = chessBoard.getAdjacentSquare(squareAdjacentNorth, Direction.North);
            ChessSquare squareTwoSquaresSouth = chessBoard.getAdjacentSquare(squareAdjacentSouth, Direction.South);

            // black 
            if (startingChessSquare.PieceOnSquare.PieceColor == 'b')
            {
                // consider move forward 1
                if (squareAdjacentSouth.PieceOnSquare.PieceType == PieceType.None)
                {
                    if (squareAdjacentNorth.UciSquareName.EndsWith("1"))
                    {
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentSouth.UciSquareName + "q");
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentSouth.UciSquareName + "r");
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentSouth.UciSquareName + "b");
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentSouth.UciSquareName + "n");
                    }
                    else
                    {
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentSouth.UciSquareName);
                    }
                }
                // consider move forward 2
                if (startingChessSquare.UciSquareName.EndsWith("7"))
                {
                    if ((squareAdjacentSouth.PieceOnSquare.PieceType == PieceType.None) &&
                        (squareTwoSquaresSouth.PieceOnSquare.PieceType == PieceType.None))
                    {
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareTwoSquaresSouth.UciSquareName);
                    }
                }
                // consider enpassant capture
                if (chessBoard.EnPassantTargetSquare != null)
                {
                    ChessSquare epSquare = chessBoard.EnPassantTargetSquare;
                    ChessSquare northwestSquare = chessBoard.getAdjacentSquare(epSquare, Direction.NorthWest);
                    ChessSquare northeastSquare = chessBoard.getAdjacentSquare(epSquare, Direction.NorthEast);

                    if ((northwestSquare != null) && (startingChessSquare == northwestSquare))
                    {
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + epSquare.UciSquareName);

                    }
                    if ((northeastSquare != null) && (startingChessSquare == northeastSquare))
                    {
                        listPossibleUciMoves.Add(startingChessSquare.UciSquareName + epSquare.UciSquareName);
                    }
                }
                // consider capture
                if ((squareAdjacentSouthEast != null) &&
                    (squareAdjacentSouthEast.PieceOnSquare.PieceType != PieceType.None) &&
                    (squareAdjacentSouthEast.PieceOnSquare.PieceColor == 'w'))
                {
                    listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentSouthEast.UciSquareName);
                }
                if ((squareAdjacentSouthWest != null) &&
                    (squareAdjacentSouthWest.PieceOnSquare.PieceType != PieceType.None) &&
                    (squareAdjacentSouthWest.PieceOnSquare.PieceColor == 'w'))
                {
                    listPossibleUciMoves.Add(startingChessSquare.UciSquareName + squareAdjacentSouthWest.UciSquareName);
                }
            }
            foreach (string possibleUciMove in listPossibleUciMoves)
            {
                // make sure we dont expose the king to check by moving a pinned piece!
                ChessBoard tempChessBoard = chessBoard.clone();
                // Remember, this toggles the activePlayer
                tempChessBoard.PerformUciMove(possibleUciMove);
                // Tricky! Toggle the active player so isActivePlayerInCheck considers correct target king!
                tempChessBoard.toggleActivePlayer();
                if (!UtilitiesActivePlayerInCheck.isActivePlayerInCheck(tempChessBoard))
                {
                    listUciMoves.Add(possibleUciMove);
                }
            }
            return listUciMoves;
        }

    }
}
