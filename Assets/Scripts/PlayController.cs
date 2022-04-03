using OthelloMinimaxAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    // Start is called before the first frame update
    private Board currentBoard;
    private Board.PIECE humanPlayerPiece;

    public static string humanPiece = string.Empty;

    public Collider[] pieceRowColliders;
    public Collider[] pieceColColliders;
    public GameObject pieceFolder;

    private Board.PIECE currentPlayer;

    public MouseRaycast mouseRayCast;

    public GameObject piecePrefab;
    private GameObject[,] pieces;

    public float aiDelayTime = 1;
    private float waitTime;

    public enum States {Playing, GameOver };

    public States currentState;

    public string currentPlayerColor;

    public static int minimaxDepth = 1;

    public string winnerColor;
    public bool didHumanWin = false;

    void Start()
    {
        if (humanPiece.ToUpper().Equals("BLACK"))
        {
            humanPlayerPiece = Board.PIECE.BLACK;
        } else
        {
            humanPlayerPiece = Board.PIECE.WHITE;
        }
        currentBoard = new Board(humanPlayerPiece);
        pieces = new GameObject[8, 8];
         
        addPieceToUnityBoard(Board.PIECE.WHITE, 3, 3);
        addPieceToUnityBoard(Board.PIECE.BLACK, 3, 4);
        addPieceToUnityBoard(Board.PIECE.BLACK, 4, 3);
        addPieceToUnityBoard(Board.PIECE.WHITE, 4, 4);

        waitTime = 0;

        currentState = States.Playing;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentPlayer = currentBoard.currentPlayer;

        if (currentBoard.isGameOver())
        {
            winnerColor = currentBoard.getWinner().ToString();

            didHumanWin = winnerColor.Equals(humanPlayerPiece.ToString());

            currentState = States.GameOver;
            return;
        }

        
        currentPlayerColor = currentPlayer.ToString();

        if (currentPlayer == humanPlayerPiece)
        {
            int row = mouseRayCast.clickedRowNumber;
            int col = mouseRayCast.clickedColNumber;

            if (Input.GetMouseButtonDown(0) && currentBoard.makeMove(row, col))
            {
                addPieceToUnityBoard(currentPlayer, row, col);

                foreach ((int r, int c) point in currentBoard.lastFlipped)
                {
                    flipPiece(point.r, point.c);
                }
            }
        }
        else
        {
            waitTime += Time.deltaTime;
            if (waitTime > aiDelayTime)
            {
                AIaction(currentPlayer, minimaxDepth);
                waitTime = 0;
            }
        }

    }

    private void AIaction(Board.PIECE currentPlayer, int depth)
    {
        (int score, Move move) = currentBoard.minimax(currentBoard, Board.GetOppositePiece(humanPlayerPiece), depth, 0, int.MinValue, int.MaxValue);

        if (move == null)
        {
            currentBoard.terminal = true;
            return;
        }

        if (currentBoard.makeMove(move.row, move.col))
        {
            addPieceToUnityBoard(currentPlayer, move.row, move.col);
            foreach ((int r, int c) point in currentBoard.lastFlipped)
            {
                flipPiece(point.r, point.c);
            }
        }
    }

    private void addPieceToUnityBoard(Board.PIECE who, int row, int col)
    {
        Vector3 dropPosition = new Vector3(pieceRowColliders[row].transform.position.x, 4f, pieceColColliders[col].transform.position.z);

        pieces[row,col] = Instantiate(piecePrefab, dropPosition, Quaternion.identity);

        pieces[row, col].transform.parent = pieceFolder.transform; //add to piece folder
        
        Rigidbody pieceRigidBody = pieces[row,col].AddComponent<Rigidbody>();
        pieceRigidBody.freezeRotation = true;

        BoxCollider pieceCollider = pieces[row, col].AddComponent<BoxCollider>();
        pieceCollider.size = new Vector3(0.8f, 0.2f, 0.8f);

        if(who == Board.PIECE.WHITE)
        {
            flipPiece(row, col);
        }
       
    }

    private void flipPiece(int row, int col)
    {
        Animator pieceAnimator = pieces[row, col].GetComponentInChildren<Animator>();

        pieceAnimator.SetTrigger("Flip");
        pieceAnimator.transform.position = pieces[row, col].transform.position;
    }

    private void fillBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                addPieceToUnityBoard(Board.PIECE.WHITE, i, j);
            }
        }
    }


}
