using GameOff2023.Common.Data.DataStore;
using UnityEngine;

namespace GameOff2023.Common.Domain.Repository
{
    public sealed class SaveRepository
    {
        public SaveData Load()
        {
            var data = ES3.Load(SaveConfig.ES3_KEY, defaultValue: "");

            if (string.IsNullOrEmpty(data))
            {
                return Create();
            }

            return JsonUtility.FromJson<SaveData>(data);
        }

        private SaveData Create()
        {
            var newData = SaveData.Create();
            Save(newData);

            return newData;
        }

        public void SaveUid(string uid)
        {
            var loadData = Load();
            loadData.uid = uid;
            Save(loadData);
        }

        public void SaveBgm(float bgmVolume)
        {
            var loadData = Load();
            loadData.bgmVolume = bgmVolume;
            Save(loadData);
        }

        public void SaveSe(float seVolume)
        {
            var loadData = Load();
            loadData.seVolume = seVolume;
            Save(loadData);
        }

        public void Delete()
        {
            ES3.DeleteKey(SaveConfig.ES3_KEY);
        }

        private void Save(SaveData saveData)
        {
            var data = JsonUtility.ToJson(saveData);
            ES3.Save(SaveConfig.ES3_KEY, data);
        }
    }
}