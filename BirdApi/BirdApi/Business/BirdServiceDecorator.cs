
using System;
using System.Collections.Generic;
using BirdsApi.Models;
using NLog;

namespace BirdsApi.Business
{
    public class BirdServiceDecorator : IBirdService
    {
        private readonly IBirdService _inner;
        private readonly ILogger _logger;

        public BirdServiceDecorator(IBirdService inner, ILogger logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public List<string> GetAllVisibleBirds()
        {
            _logger.Debug("GetAllBirds is called");
            try
            {

                var result = _inner.GetAllVisibleBirds();
                _logger.Debug($"got birds successsfully. Got {result.Count}");
                return result;
            }
            catch (Exception exception)
            {
                _logger.Fatal(exception, "couldn't get birds");
                throw;
            }
        }

        public BirdPersistedDto GetBird(string birdId)
        {
            _logger.Debug($"GetBird({birdId}) is called");
            try
            {

                var result = _inner.GetBird(birdId);
                _logger.Debug($"GetBird({birdId}) successsfully. Got {result}");
                return result;
            }
            catch (Exception exception)
            {
                _logger.Fatal(exception, $"couldn't get bird {birdId}");
                throw;
            }
        }

        public string PersistBird(BirdDto birdDto)
        {
            _logger.Debug($"PersistBird({birdDto}) is called");
            try
            {

                var result = _inner.PersistBird(birdDto);
                _logger.Debug($"PersistBird({birdDto}) successsfully. Got {result}");
                return result;
            }
            catch (Exception exception)
            {
                _logger.Fatal(exception, $"couldn't get bird {birdDto}");
                throw;
            }
        }

        public void UpdateBird(string birdId, BirdDto birdDto)
        {
            _logger.Debug($"UpdateBird({birdId}) is called");
            try
            {

                _inner.UpdateBird(birdId, birdDto);
                _logger.Debug($"UpdateBird({birdId}) successsfully.");
            }
            catch (Exception exception)
            {
                _logger.Fatal(exception, $"couldn't update bird {birdId}");
                throw;
            }
        }
        public void DeleteBird(string birdId)
        {
            _logger.Debug($"DeleteBird({birdId}) is called");
            try
            {

                _inner.DeleteBird(birdId);
                _logger.Debug($"DeleteBird({birdId}) successsfully.");
            }
            catch (Exception exception)
            {
                _logger.Fatal(exception, $"couldn't delete bird {birdId}");
                throw;
            }
        }
    }
}
