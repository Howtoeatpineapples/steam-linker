using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


using Steam.Models.SteamCommunity;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;




namespace Steam_Linker_2._0
{
    public partial class Form1 : Form
    {
        private List<ulong> AllHosts { get; set; }
        private SteamUser SteamInterface { get; set; }
        private SynchronizationContext m_SynchronizationContext;
        public List<ISteamWebResponse<IReadOnlyCollection<FriendModel>>> AllFriendModels { get; set; }
        public List<ISteamWebResponse<PlayerSummaryModel>> AllPlayerSummaryModels { get; set; }
        



        public Form1()
        {
            InitializeComponent();
            m_SynchronizationContext = SynchronizationContext.Current;
            MessageBox.Show("Feel free to share, redistribute and use! Enjoy.", "Steam Linker By: howtoeatpineapples");

        }

        private void showInfo()
        {
            MessageBox.Show("Enter your steamAPI key into the top box,\n\n" +
    "Enter the steamID64s as arguments into the larger box, they should be formatted as so:\n" +
    "76561198077279908,76561198077279909,76561198077279910\n" +
    "OR\n" +
    "76561198077279908 76561198077279909 etc.\n\n" +
    "There is no limit on the amount of inputs however processing time grows exponentially as you add more accounts\n\n" +
    "Bugs? Questions? Need help? add me on steam: 76561198077279908",
    "Steam Linker by howtoeatpineapples");
        }

        private List<PlayerSummaryModel> RemoveISteamWebResponse()
        {
            List<PlayerSummaryModel> TempList = new List<PlayerSummaryModel>();

            foreach (var x in AllPlayerSummaryModels)
            {
                TempList.Add(x.Data);
            }
            return TempList;
        }

        private async Task<bool> GetPlayerSummaryModel(FriendModel friend)
        {
            try
            {
                //Task<ISteamWebResponse<PlayerSummaryModel>> y = null;
                var FriendPlayerSummary = await SteamInterface.GetPlayerSummaryAsync(friend.SteamId);
                if (FriendPlayerSummary.Data != null)
                {
                    AllPlayerSummaryModels.Add(FriendPlayerSummary);
                    return true;
                }
                return false;
            }

            catch (Exception hEx)
            {
                MessageBox.Show("ERROR when getting PlayerSummaryModels:: " + hEx.Message);
                return false;
            }

        }

        private async void SetAllPlayerSummaryModels(List<FriendModel> FriendModels)
        {
            
            var PlayerSummaryModels = new List<ISteamWebResponse<PlayerSummaryModel>>();
            foreach (var y in FriendModels)
            {
                bool FriendPlayerSummarySuccess = await GetPlayerSummaryModel(y);
                if (!FriendPlayerSummarySuccess)
                {
                    MessageBox.Show("FriendPlayerSummarySuccess = FALSE");
                }
            }
        }

        private List<FriendModel> CleanList(List<FriendModel> inputList)
        {
            List<FriendModel> TempList = new List<FriendModel>();

            foreach (FriendModel u1 in inputList)
            {
                bool duplicatefound = false;
                foreach (FriendModel u2 in TempList)
                    if (u1.SteamId == u2.SteamId)
                        duplicatefound = true;

                if (!duplicatefound)
                    TempList.Add(u1);
            }
            return TempList;
        }

        private List<FriendModel> CalculateMutualFriends()
        {
            //Stopwatch sw = Stopwatch.StartNew();
            var result = new List<FriendModel>();
            var hs = new HashSet<FriendModel>(new FriendModelComparer());
            foreach (var x in AllFriendModels)
            {
                foreach (var y in x.Data)
                {
                    if (hs.Add(y))
                        continue;

                    result.Add(y);
                }
            }
           // long ts = sw.ElapsedMilliseconds;
            // how long the search took (ms) 
           // MessageBox.Show(ts.ToString());
            result.OrderBy(x => x.FriendSince).ToList();
            return result;
        }

        // Gets the FriendData of a specified person
        private async Task<ISteamWebResponse<IReadOnlyCollection<FriendModel>>> GetFriendModels(int AllHostIndex)
        {

            string SID64 = string.Empty;
            try
            {
                var x = SteamInterface.GetFriendsListAsync(Convert.ToUInt64(AllHosts[AllHostIndex]));
                SID64 = Convert.ToString(AllHosts[AllHostIndex]);
                return await x;
            }

            catch (Exception hEx)
            {
                MessageBox.Show(SID64 + " ::ERROR:: " + hEx.Message);
                return null;
            }

        }

        private async void SetAllFriendData()
        {
            int count = 0;
            foreach (var y in AllHosts)
            {
                // Put in a steamID and it pops out a list of Friend Models
                var x = await GetFriendModels(count);
                if (x == null)
                {
                    count++;
                    continue;
                }
                // Adds the list of Friend Models to the AllFriendData list
                AllFriendModels.Add (x);
                count++;
            } 
        }

        private void SetAllHosts(RichTextBox RTB_Input)
        {
            char[] delimiterChars = { ' ', ',', '.', '\t', '\n', '-', ':' };
            string text = RTB_Input.Text;
            string[] words = text.Split(delimiterChars);

            int count = 0;
            foreach (var x in words)
            {
               AllHosts.Add(Convert.ToUInt64(words[count]));
               count++;
            }
          
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(1000);
        }

        // Runs the processes regarding the location of all mutual friends
        private async void Button_Search_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialising new instances
                AllHosts = new List<ulong>();
                SteamInterface = new SteamUser(textBox_Key.Text);
                AllFriendModels = new List<ISteamWebResponse<IReadOnlyCollection<FriendModel>>>();
                AllPlayerSummaryModels = new List<ISteamWebResponse<PlayerSummaryModel>>();

                AllHosts.Clear();
                SetAllHosts(richTextBox_HostInput);

                SetAllFriendData();
                var searchtext = button_Search.Text;
                // Does all friend data get values?
                int tic = 0;
                do {
                    button_Search.Text = "Loading...";
                    await Task.Delay(1000);
                    tic++;
                    if (tic >= AllHosts.Count)
                    {
                        label_Status.Text = "Timed out";
                        break;
                    }
                } while (!(AllFriendModels.Count == AllHosts.Count));
                button_Search.Text = searchtext;
                // Clean up the list a bit
                var MutualFriends = CalculateMutualFriends();
                var cleanedList = CleanList(MutualFriends);

                SetAllPlayerSummaryModels(cleanedList);
                tic = 0;
                do
                {
                    button_Search.Text = "Loading...";
                    await Task.Delay(1000);
                    tic++;
                    if (tic >= 10)
                    {
                        label_Status.Text = "Timed out";
                        break;
                    }
                } while (!(AllPlayerSummaryModels.Count == cleanedList.Count));
                button_Search.Text = searchtext;

                var result = RemoveISteamWebResponse();
                dataGridView1.DataSource = result;
                
                //dataGridView1.DataSource = AllFriendData[0].Data;
                dataGridView1.AutoResizeColumns();
                label_Status.Text = Convert.ToString(result.Count());

                 
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            catch (Exception Ex)
            {
                label_Status.Text = Ex.Message;
            }
        }

        private void button_info_Click(object sender, EventArgs e)
        {
            showInfo();
        }
    }
}
