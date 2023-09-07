﻿using Garden.Models;

namespace Garden.BLL.Interfaces
{
    public interface IGardenBLL
    {
        public GardenEntity GetGarden(string id);

        public GardenEntity GetGardenRandomly();

        public List<GardenEntity> GetUserGardens(string id);

        public List<GardenEntity> GetPopularGardens(int page);

        public List<GardenEntity> GetRecentGardens(int page);

        public List<GardenEntity> GetTopGardens();

        public List<GardenComments> GetCommentsByGardenId(string garden_id);
        public bool AddGardenComment(string userId, string gardenId, string comment);

        public string Insert(GardenEntity garden);
    }
}

