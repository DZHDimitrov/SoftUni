namespace FootballManager.Interfaces
{

    using FootballManager.ViewModels;

    public interface IPlayerService
    {
        public IEnumerable<PlayerViewModel> GetAllPlayers();

        public bool AddPlayer(CreatePlayerViewModel model, string userId);

        public bool AddToCollection(int playerId, string userId);

        public IEnumerable<PlayerViewModel> GetUserCollection(string userId);

        public bool RemoveFromCollection(int playerId, string userId);
    }
}
