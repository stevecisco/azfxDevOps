namespace Sudoku.Models.Entities
{
    public class PuzzleDTO
    {
        public Guid Id { get; set; }

        public Guid? ParentPuzzleId { get; set; }

        public string? ParentChoice { get; set; }

        public PuzzleStatuses PuzzleStatus { get; set; }

        public List<SquareDTO> Squares { get; set; }

        public DateTime SubmissionDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public PuzzleDTO() 
        {
            Squares = new List<SquareDTO>();
            Id = Guid.NewGuid();
        }
    }
}