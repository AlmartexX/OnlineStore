﻿namespace OnlineStore.DAL.Settings
{
    public class PaginationSettings
    {
        private const int maxPageSize = 25;
        private int _pageSize = 5;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
