using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;

namespace SwqlStudio.Playback
{
    internal class PlaybackManager
    {
        private static readonly SolarWinds.Logging.Log log = new SolarWinds.Logging.Log();

        public static void StartPlayback(PlaybackItem file)
        {
            ThreadPool.QueueUserWorkItem(RunPlaybackFile, file);
        }

        private static void RunPlaybackFile(object f)
        {
            try
            {
                
                if (f != null)
                {
                    var playbackItem = f as PlaybackItem;
                    if (playbackItem != null)
                    {
                        log.DebugFormat("Playing back file: {0}", playbackItem.FileName);
                        var sb = new StringBuilder();
                        using (var sr = new StreamReader(playbackItem.FileName))
                        {
                            String line;
                            // Read and display lines from the file until the end of 
                            // the file is reached.
                            while ((line = sr.ReadLine()) != null)
                            {
                                sb.AppendLine(line);
                            }
                        }
                        var innerXml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><ProfileItems xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><ProfileItems>" + sb + "</ProfileItems></ProfileItems>";

                        var profileItems = ProfileItems.Deserialize(innerXml);
                        var stopwatch = Stopwatch.StartNew();
                        foreach (var profileItem in profileItems.Items)
                        {
                            ExecuteQuery(profileItem, playbackItem.ConnectionInfo, playbackItem);
                        }
                        playbackItem.QueryTab.AppendLogTabLine(string.Format("Executed {0} queries in {1} ms.", profileItems.Items.Count(), stopwatch.ElapsedMilliseconds));
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }

        private static readonly Regex re = new Regex("RETURN XML (RAW|AUTO)");

        private static void ExecuteQuery(ProfileItem item, ConnectionInfo info, PlaybackItem playbackItem)
        {
            try
            {
                info.QueryParameters = item.GetQueryParameters();
                var results = info.Query(re.Replace(item.Query, string.Empty));
            }
            catch (Exception e)
            {
                playbackItem.QueryTab.AppendLogTabLine(string.Format("{0} {1}", item.Query, e));
            }
        }
    }
}
