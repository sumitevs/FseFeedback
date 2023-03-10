using FseFeedback.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FseFeedback.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PscTool> pscTools;
        public ObservableCollection<PscTool> PscTools
        {
            get { return pscTools; }
            set
            {
                pscTools = value;
                OnPropertyChanged(nameof(PscTools));
            }
        }
        private PscTool selectedTool;
        public PscTool SelectedTool
        {
            get { return selectedTool; }
            set { selectedTool = value; }
        }


        private ObservableCollection<PscTool> pscGroups;
        public ObservableCollection<PscTool> PscGroups
        {
            get { return pscGroups; }
            set
            {
                pscGroups = value;
                OnPropertyChanged(nameof(PscGroups));
            }
        }
        private PscTool selectedGroup;
        public PscTool SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                selectedGroup = value; 
                OnPropertyChanged(nameof(SelectedGroup));
                OnGroupChanged(value);
            }
        }

        private void OnGroupChanged(PscTool value)
        {
            if (value.Name == "Other")
            {
                PscTools = new ObservableCollection<PscTool>()
                {
                    new PscTool(){Name = "Service Log Book"},
                    new PscTool(){Name = "CopyFileFtpRoot"},
                    new PscTool(){Name = "Copy Event Logging"},
                    new PscTool(){Name = "Clear Log&Trace"},
                    new PscTool(){Name = "Change Profile"},
                    new PscTool(){Name = "Other"}
                };
                SelectedTool = PscTools[5];
            } else if (value.Name == "Installation")
            {
                PscTools = new ObservableCollection<PscTool>()
                {
                    new PscTool(){Name = "Local sw update"},
                    new PscTool(){Name = "Remote sw update"},
                    new PscTool(){Name = "Add-on sw"},
                    new PscTool(){Name = "Printer Driver"},
                    new PscTool(){Name = "Re-install System"},
                    new PscTool(){Name = "Other"}
                };
                SelectedTool = PscTools[5];
            } else if (value.Name == "Backup & Restore")
            {
                PscTools = new ObservableCollection<PscTool>()
                {
                    new PscTool(){Name = "Backup"},
                    new PscTool(){Name = "Restore"},
                    new PscTool(){Name = "Other"}
                };
                SelectedTool = PscTools[2];
            }
        }

        private ObservableCollection<PscTool> pscActivities;
        public ObservableCollection<PscTool> PscActivities
        {
            get { return pscActivities; }
            set { pscActivities = value; }
        }
        private PscTool selectedActivity;

        public event PropertyChangedEventHandler PropertyChanged;

        public PscTool SelectedActivity
        {
            get { return selectedActivity; }
            set
            {
                selectedActivity = value;
                OnPropertyChanged(nameof(SelectedActivity));
                OnActivityChanged(value);
            }
        }

        private void OnActivityChanged(PscTool value)
        {
            if (value.Name == "System")
            {
                PscGroups = new ObservableCollection<PscTool>()
                {
                    new PscTool(){Name = "Backup & Restore"},
                    new PscTool(){Name = "Installation"},
                    new PscTool(){Name = "Other"}
                };
                SelectedGroup = PscGroups[2];
            }
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ViewModel()
        {
            PscActivities = new ObservableCollection<PscTool>()
            {
                new PscTool(){Name = "System"},
                new PscTool(){Name = "Configurations"},
                new PscTool(){Name = "Diagnostics"},
                new PscTool(){Name = "Configurations"},
                new PscTool(){Name = "Customization"},
                new PscTool(){Name = "Performance"},
                new PscTool(){Name = "Survey"},
                new PscTool(){Name = "Others"}
            };
            
        }
    }
}
