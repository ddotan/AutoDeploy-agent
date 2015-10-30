using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AutoDeploy.Application.Objects;
namespace AutoDeploy.Application.WF
{
    public partial class RemoteConfigurationForm : Form
    {
        AutoDeployAgent m_AutoDeployAgent;

        public RemoteConfigurationForm(AutoDeployAgent i_AutoDeployAgent)
        {
            m_AutoDeployAgent = i_AutoDeployAgent;
            InitializeComponent();
            textBoxUserName.Text = m_AutoDeployAgent.Service.GetRemotePathUserName();
            textBoxPassword.Text = m_AutoDeployAgent.Service.GetRemotePathPassword();
            textBoxRemotePath.Text = m_AutoDeployAgent.Service.GetRemotePath();
            textBoxExeParams.Text = m_AutoDeployAgent.Service.GetAdditionalExeParams();
            textBoxName.Text = m_AutoDeployAgent.Service.GetName();
            textBoxInstalltionPath.Text = m_AutoDeployAgent.Service.GetInstalltionPath();
            textBoxServiceName.Text = m_AutoDeployAgent.Service.GetServiceName();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            m_AutoDeployAgent.Service.SetRemotePath(textBoxRemotePath.Text);
            m_AutoDeployAgent.Service.SetRemotePathUserName(textBoxUserName.Text);
            m_AutoDeployAgent.Service.SetRemotePathPassword(textBoxPassword.Text);
            m_AutoDeployAgent.Service.SetAdditionalExeParams(textBoxExeParams.Text);
            m_AutoDeployAgent.Service.SetName(textBoxName.Text);
            m_AutoDeployAgent.Service.SetServiceName(textBoxServiceName.Text);
            m_AutoDeployAgent.Service.SetInstalltionPath(textBoxInstalltionPath.Text);
            m_AutoDeployAgent.Service.SaveAppConfig();
            this.Close();
        }



    }
}
