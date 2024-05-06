using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ManagingClients._Data.Scripts.SaveManager
{
    public abstract class SaveManager
    {

        public virtual bool SaveDataBaseEPower()
        {
            string path = this.GetPathToSaveData();
            var dataSaved = this.GetDataSave();
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, dataSaved);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

      
        public virtual object ReadDataAllLineConnect(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                object dataTransfered = bf.Deserialize(fs);
                
                fs.Close();

                return dataTransfered;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        protected virtual string GetPathToSaveData()
        {
            return "";
        }
        protected abstract object GetDataSave();



    }
}
