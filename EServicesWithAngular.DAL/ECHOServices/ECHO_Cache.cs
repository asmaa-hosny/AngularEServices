using ERB_CountryService;
using ERB_CurrencyService;
using ERP_EmployeeServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.DAL.ECHOServices
{
    public class ECHO_Cache
    {
        private static employee[] _allEmployees = null;
        private static DateTime? _allEmployeesUpdated = null;
        private static long _allEmployeesExpiryInDays = 2;
        public static employee[] AllEmployees
        {
            get
            {
                if (_allEmployeesUpdated == null || (_allEmployeesUpdated.Value.AddDays(_allEmployeesExpiryInDays) < DateTime.Now))
                {
                    _allEmployees = null;
                    return null;
                }
                else
                    return _allEmployees;
            }
            set
            {
                _allEmployees = value;
                _allEmployeesUpdated = DateTime.Now;
            }
        }

        private static vendor[] _allVendors = null;
        private static DateTime? _allVendorsUpdated = null;
        private static long _allVendorsExpiryInDays = 2;
        public static vendor[] AllVendors
        {
            get
            {
                if (_allVendorsUpdated == null || (_allVendorsUpdated.Value.AddDays(_allVendorsExpiryInDays) < DateTime.Now))
                {
                    _allVendors = null;
                    return null;
                }
                else
                    return _allVendors;
            }
            set
            {
                _allVendors = value;
                _allVendorsUpdated = DateTime.Now;
            }
        }

        private static country[] _allCountries = null;
        private static DateTime? _allCountriesUpdated = null;
        private static long _allCountriesExpiryInDays = 2;
        public static country[] AllCountries
        {
            get
            {
                if (_allCountriesUpdated == null || (_allCountriesUpdated.Value.AddDays(_allCountriesExpiryInDays) < DateTime.Now))
                {
                    _allCountries = null;
                    return null;
                }
                else
                    return _allCountries;
            }
            set
            {
                _allCountries = value;
                _allCountriesUpdated = DateTime.Now;
            }
        }

        private static currency[] _allActiveCurrencies = null;
        private static DateTime? _allActiveCurrenciesUpdated = null;
        private static long _allActiveCurrenciesExpiryInDays = 2;
        public static currency[] AllActiveCurrencies
        {
            get
            {
                if (_allActiveCurrenciesUpdated == null || (_allActiveCurrenciesUpdated.Value.AddDays(_allActiveCurrenciesExpiryInDays) < DateTime.Now))
                {
                    _allActiveCurrencies = null;
                    return null;
                }
                else
                    return _allActiveCurrencies;
            }
            set
            {
                _allActiveCurrencies = value;
                _allActiveCurrenciesUpdated = DateTime.Now;
            }
        }

        private static ERP_RefListService.refList[] _allFlightTypes = null;
        private static DateTime? _allFlightTypesUpdated = null;
        private static long _allFlightTypesExpiryInDays = 2;
        public static ERP_RefListService.refList[] AllFlightTypes
        {
            get
            {
                if (_allFlightTypesUpdated == null || (_allFlightTypesUpdated.Value.AddDays(_allFlightTypesExpiryInDays) < DateTime.Now))
                {
                    _allFlightTypes = null;
                    return null;
                }
                else
                    return _allFlightTypes;
            }
            set
            {
                _allFlightTypes = value;
                _allFlightTypesUpdated = DateTime.Now;
            }
        }

        private static ERP_RefListService.refList[] _allAirClasses = null;
        private static DateTime? _allAirClassesUpdated = null;
        private static long _allAirClassesExpiryInDays = 2;
        public static ERP_RefListService.refList[] AllAirClasses
        {
            get
            {
                if (_allAirClassesUpdated == null || (_allAirClassesUpdated.Value.AddDays(_allAirClassesExpiryInDays) < DateTime.Now))
                {
                    _allAirClasses = null;
                    return null;
                }
                else
                    return _allAirClasses;
            }
            set
            {
                _allAirClasses = value;
                _allAirClassesUpdated = DateTime.Now;
            }
        }
    }
}