using System;
using System.Collections.Generic;

namespace BestPrice.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            Notifications = new HashSet<Notifications>();
            SearchHistories = new HashSet<SearchHistories>();
            Wishlists = new HashSet<Wishlists>();
        }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public short EmailConfirmed { get; set; }
        public string PendingEmailChange { get; set; }
        public short LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public short PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public short TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public int? LocationId { get; set; }
        public short IsRegistered { get; set; }
        public string Location { get; set; }
        public short GetNotified { get; set; }
        public short SaveSearches { get; set; }

        public virtual Locations LocationNavigation { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<SearchHistories> SearchHistories { get; set; }
        public virtual ICollection<Wishlists> Wishlists { get; set; }
    }
}
