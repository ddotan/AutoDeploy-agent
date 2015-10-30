using AutoDeploy.Application.Engine;
using AutoDeploy.Application.Objects;
using Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutoDeploy.Application.WF
{
    public partial class MainForm : Form
    {
        List<AutoDeployAgent> m_Agents;
        private LogManager m_logManager = LogManager.Instance;
        private AutoDeployManager m_AutoDeployManager = new AutoDeployManager();
        public MainForm()
        {

            InitializeComponent();
            try
            {
                m_Agents = m_AutoDeployManager.Agents;
                dataGridViewAgents.DataSource = m_Agents;
            }
            catch (Exception ex)
            {
                m_logManager.WriteError("Failed to load , performing shutdown !!!");

                m_logManager.WriteError(ex.Message);
                System.Windows.Forms.Application.Exit();

            }
            refreshAgentTimer(1);
        }
        public AutoDeployAgent GetSelectedAgent()
        {
            AutoDeployAgent agent = null;
            if (dataGridViewAgents.SelectedCells.Count > 0)
            {
                agent = (AutoDeployAgent)dataGridViewAgents.CurrentRow.DataBoundItem;

            }
            return agent;
        }
        private void writeToLogs(string i_Msg, string i_AgentName, bool i_IsERROR)
        {

            string msg = i_AgentName + " : " + i_Msg;
            if (i_IsERROR)
            {
                m_logManager.WriteError(msg);
            }
            else
            {
                m_logManager.WriteInfo(msg);
            }
            richTextBoxLog.Text += msg + "\n";
        }
        private void buttonDeploy_Click(object sender, EventArgs e)
        {
            AutoDeployAgent agent = GetSelectedAgent();
            if (agent != null)
            {
                try
                {
                    agent.Service.Deploy();
                    writeToLogs("Deploy was done successfully", agent.Name, false);
                }
                catch (Exception ex)
                {
                    writeToLogs(ex.Message, agent.Name, true);
                }
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            AutoDeployAgent agent = GetSelectedAgent();
            if (agent != null)
            {
                try
                {
                    agent.Service.StartService();
                    writeToLogs("Service started.", agent.Name, false);

                }
                catch (Exception ex)
                {
                    writeToLogs(ex.Message, agent.Name, true);


                }
            }
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            AutoDeployAgent agent = GetSelectedAgent();
            if (agent != null)
            {
                try
                {
                    agent.Service.StopService();
                    writeToLogs("Service Stopped.", agent.Name, false);

                }
                catch (Exception ex)
                {
                    writeToLogs(ex.Message, agent.Name, true);
                }
            }
        }
        private void buttonStartAll_Click(object sender, EventArgs e)
        {
            foreach (AutoDeployAgent agent in m_Agents)
            {
                try
                {
                    if (!agent.ServiceRunning)
                    {
                        agent.Service.StartService();
                        writeToLogs("Service Started.", agent.Name, false);

                        agent.RefreshInfo();
                    }
                }
                catch (Exception ex)
                {
                    writeToLogs(ex.Message, agent.Name, true);

                }
            }


        }
        private void refreshAgentTimer(int i_TimeInSeconds)
        {
            Thread tr = new Thread(() =>
                 {
                     foreach (AutoDeployAgent agent in m_Agents)
                     {
                         agent.RefreshInfo();
                     }
                     Thread.Sleep(i_TimeInSeconds * 1000);
                 });
            tr.Start();
        }
        private void buttonStopAll_Click(object sender, EventArgs e)
        {
            foreach (AutoDeployAgent agent in m_Agents)
            {
                try
                {
                    if (agent.ServiceRunning)
                    {
                        agent.Service.StopService();
                        writeToLogs("Service Stopped.", agent.Name, false);
                        agent.RefreshInfo();
                    }
                }
                catch (Exception ex)
                {
                    writeToLogs(ex.Message, agent.Name, false);

                }
            }
        }
        private void dataGridViewAgents_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AutoDeployAgent agent = GetSelectedAgent();
            agent.RefreshInfo();
            if (agent.ServiceRunning)
            {
                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
            }
            else
            {
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
            }
        }

        private void buttonRemoteConfig_Click(object sender, EventArgs e)
        {
            AutoDeployAgent agent = GetSelectedAgent();
            if (agent != null)
            {
                RemoteConfigurationForm remoteConfigForm = new RemoteConfigurationForm(agent);
                remoteConfigForm.ShowDialog();
            }
        }

        private void buttonDeployAll_Click(object sender, EventArgs e)
        {
            foreach (AutoDeployAgent agent in m_Agents)
            {
                try
                {
                    agent.Service.Deploy();
                }
                catch (Exception ex)
                {
                    writeToLogs(ex.Message, agent.Name, false);


                }
            }
        }
    }
}

