namespace FootballManager.Services
{
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;

    using FootballManager.Interfaces;
    using FootballManager.ViewModels;

    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public PlayerService(IRepository _repository, IValidationService _validationService)
        {
            repo = _repository;
            validationService = _validationService;
        }

        public bool AddPlayer(CreatePlayerViewModel model,string userId)
        {
            var isSuccessfullyAdded = true;

            var isValid = validationService.ValidateModel(model);

            if (!isValid)
            {
                return false;
            }

            byte speed = 0;
            byte endurance = 0;

            if (!byte.TryParse(model.Speed, out speed) || !byte.TryParse(model.Endurance, out endurance))
            {
                return false;
            }

            if (speed < 0 || speed > 10 || endurance < 0 || endurance > 10)
            {
                return false;
            }

            var player = new Player
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Position = model.Position,
                Speed = speed,
                Endurance = endurance,
            };

            var userPlayer = new UserPlayer
            {
                Player = player,
                UserId = userId,
            };

            try
            {
                repo.Add(player);
                repo.Add(userPlayer);

                repo.SaveChanges();
            }
            catch (Exception)
            {
                isSuccessfullyAdded = false;
            }

            return isSuccessfullyAdded;
        }

        public bool AddToCollection(int playerId, string userId)
        {
            var isAddedSuccessfully = true;

            var player = repo.All<Player>().Where(p => p.Id == playerId).FirstOrDefault();

            if (player == null)
            {
                return false;
            }

            if (repo.All<UserPlayer>().Any(up => up.PlayerId == playerId && up.UserId == userId))
            {
                return false;
            }

            var userPlayer = new UserPlayer
            {
                PlayerId = playerId,
                UserId = userId,
            };

            try
            {
                repo.Add(userPlayer);
                repo.SaveChanges();
            }
            catch (Exception)
            {
                isAddedSuccessfully = false;
            }

            return isAddedSuccessfully;
        }

        public IEnumerable<PlayerViewModel> GetAllPlayers()
        {
            return repo
                .All<Player>()
                .Select(p => new PlayerViewModel
                {
                    PlayerId = p.Id,
                    Description = p.Description,
                    Endurance = p.Endurance,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed
                }).ToList();
        }

        public IEnumerable<PlayerViewModel> GetUserCollection(string userId)
        {
            return repo
                .All<UserPlayer>()
                .Where(up => up.UserId == userId)
                .Select(up => new PlayerViewModel
                {
                    PlayerId = up.PlayerId,
                    ImageUrl = up.Player.ImageUrl,
                    FullName = up.Player.FullName,
                    Position = up.Player.Position,
                    Endurance = up.Player.Endurance,
                    Speed = up.Player.Speed,
                    Description = up.Player.Description
                }).ToList();
        }

        public bool RemoveFromCollection(int playerId, string userId)
        {
            var isSuccessfullyRemoved = true;

            var player = repo
                .All<Player>()
                .FirstOrDefault(p => p.Id == playerId);

            if (player == null)
            {
                return false;
            }

            var userPlayer = repo
                .All<UserPlayer>()
                .Where(up => up.PlayerId == playerId && up.UserId == userId)
                .FirstOrDefault();

            if (userPlayer == null)
            {
                return false;
            }


            try
            {
                repo.Remove(userPlayer);
                repo.SaveChanges();

            }
            catch (Exception)
            {
                isSuccessfullyRemoved = false;
            }

            return isSuccessfullyRemoved;
        }
    }
}
