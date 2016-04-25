using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Operation.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class PointViewModel : ViewModelBase
    {
        public ObservableCollection<Point> Points { get; }
        /// <summary>
        /// Initializes a new instance of the PointViewModel class.
        /// </summary>
        public PointViewModel()
        {

            Points = new ObservableCollection<Point>();
            foreach (var i in Enumerable.Range(1, 1000).Where(x => x % 13 == 0))
            {
                Points.Add(new Point
                {
                    X = i,
                    Y = Math.Sin(i) * 40 + 150,
                });
            }
        }

        public Task Delay(int ms)
        {
            var tcs = new TaskCompletionSource<object>();
            var timer = new Timer(_ => tcs.SetResult(null),null, ms, Timeout.Infinite);
            tcs.Task.ContinueWith(_ => timer.Dispose());
            return tcs.Task;
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

    }
}