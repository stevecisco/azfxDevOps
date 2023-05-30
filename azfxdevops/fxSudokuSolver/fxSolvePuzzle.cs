using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sudoku.Models;
using Sudoku.Models.Entities;

namespace fxSudokuSolver
{
    public class fxSolvePuzzle
    {
        private readonly ILogger _logger;

        public fxSolvePuzzle(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<fxSolvePuzzle>();
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        [Function("fxSolvePuzzle")]
        public void Run([QueueTrigger("puzzlerequests", Connection = "cnQueuePuzzleRequests")] string myQueueItem)
        {
            _logger.LogInformation($"fxPuzzleSolver processed queue record: {myQueueItem}");
            var puzzleDto = JsonConvert.DeserializeObject<PuzzleDTO>(myQueueItem);
            if (puzzleDto != null )
            {
                _logger.LogInformation($"fxPuzzleSolver - Puzzle ID {puzzleDto.Id} received");
                var puzzle = new Puzzle(puzzleDto.Squares);
                var result = puzzle.TrySolvePuzzle(0, 100);
                if (result.Item1)
                {
                    _logger.LogInformation($"fxPuzzleSolver - Puzzle ID {puzzleDto.Id} Was Solved With One Solution");
                    _logger.LogInformation($"fxPuzzleSolver - Puzzle ID {puzzleDto.Id} Solution");
                    _logger.LogInformation("\n" + puzzle.GetAllowedDigitsFormatted());
                }
                else
                {
                    _logger.LogInformation($"fxPuzzleSolver - Puzzle ID {puzzleDto.Id} Not Solved Directly, Multiple Solutions");
                    _logger.LogInformation($"fxPuzzleSolver - Puzzle ID {puzzleDto.Id} State after {result.Item2} iterations");
                    _logger.LogInformation("\n" + puzzle.GetAllowedDigitsFormatted());
                }
            }
            else
            {
                _logger.LogError("No puzzle object received from queue");
            }
        }
    }
}
