using GalaSoft.MvvmLight;
using System;

namespace MaterialIconsGenerator.Common
{
    public class Selectable<T> : ObservableObject
    {
        private Action<bool> onStateChanged;

        public Selectable(T item, bool state = false,
            Action<bool> stateChangedListener = null)
        {
            this.Item = item;
            this.IsSelected = state;
            this.onStateChanged = stateChangedListener;
        }

        private T _item;
        public T Item
        {
            get { return this._item; }
            set { this.Set(ref this._item, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return this._isSelected; }
            set
            {
                this.Set(ref this._isSelected, value);
                this.onStateChanged?.Invoke(value);
            }
        }
    }
}