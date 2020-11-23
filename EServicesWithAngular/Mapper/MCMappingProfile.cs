using AutoMapper;
using ERB_TrainingServices;
using ERP_BusinessTripServices;
using ERP_MissionCompletionService;
using ERP_OvertimeServices;
using EServicesWithAngular.DAL.Enums;
using EServicesWithAngular.Domain;
using EServicesWithAngular.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Mapper
{
    public class MCMappingProfile : Profile
    {

        public MCMappingProfile()
        {
            CreateMap<empMission, MissionCompletion>()
             .ForMember(d => d.CityId, opt => opt.MapFrom(src => src.cityid))
             .ForMember(d => d.Id, opt => opt.MapFrom(src => src.id))
             .ForMember(d => d.MissionID, opt => opt.MapFrom(src => src.id))
             .ForMember(d => d.CountryId, opt => opt.MapFrom(src => src.countryid))
             .ForMember(d => d.AccomedationPaymentTotal, opt => opt.MapFrom(src => src.accomedation_payment_total))
             .ForMember(d => d.IsAccomedatoinProvided, opt => opt.MapFrom(src => src.isAccomedatoin_provided))
             .ForMember(d => d.IsAdvancedPaymentNeeded, opt => opt.MapFrom(src => src.isAdvancedPaymentNeeded))
             .ForMember(d => d.DateFrom, opt => opt.MapFrom(src => src.dateFrom))
             .ForMember(d => d.DateTo, opt => opt.MapFrom(src => src.dateTo))
             .ForMember(d => d.AdvancedPaymentTotal, opt => opt.MapFrom(src => src.advanced_payment_total))
             .ForMember(d => d.FoodPaymentTotal, opt => opt.MapFrom(src => src.food_payment_total))
             .ForMember(d => d.IsFoodProvided, opt => opt.MapFrom(src => src.isFoodProvided))
             .ForMember(d => d.IsTransportationProvided, opt => opt.MapFrom(src => src.isTransportationProvided))
             .ForMember(d => d.TransportationPaymentTotal, opt => opt.MapFrom(src => src.accomedation_payment_total))
             .ForMember(d => d.TotalAmount, opt => opt.MapFrom(src => src.totalAmount))
             .ForMember(d => d.GrossAmount, opt => opt.MapFrom(src => src.grossAmount))
             .ForMember(d => d.MissionTypeAr, opt => opt.MapFrom(src => src.missionTypeAr))
             .ForMember(d => d.MissionTypeEn, opt => opt.MapFrom(src => src.missionTypeEn))
             .ForMember(d => d.TransportationPaymentTotal, opt => opt.MapFrom(src => src.accomedation_payment_total))
             .ForMember(d => d.TotalAmount, opt => opt.MapFrom(src => src.totalAmount))
             .ForMember(d => d.MissionTypeID, opt => opt.MapFrom(src => src.missionTypeID))
             .ForMember(d => d.CompletedDate, opt => opt.MapFrom(src => DateTime.Parse(src.dateTo)))
             .ForMember(d => d.IsOvertime, opt => opt.MapFrom(src => src.missionTypeID == (int)MissionType.OverTimeMissionTypeID))
             .ForMember(d => d.IsTraining, opt => opt.MapFrom(src => src.missionTypeID == (int)MissionType.TrainingMissionTypeID))
             .ForMember(d => d.IsMandate, opt => opt.MapFrom(src => src.missionTypeID == (int)MissionType.MandateMissionTypeID))
             .ForMember(d => d.DocumentType,
              opt => opt.MapFrom
             (src => src.missionTypeID == (int)MissionType.TrainingMissionTypeID ?
             "HR-TR-" + src.id : src.missionTypeID == (int)MissionType.MandateMissionTypeID ?
             "HR-BT-" + src.id : "HR-OV-" + src.id)).ReverseMap();


            CreateMap<mandateRequest, BusinessTripLine>()
            .ForMember(d => d.LineID, opt => opt.MapFrom(src => src.id))
            .ForMember(d => d.CountryID, opt => opt.MapFrom(src => src.countryid))
            .ForMember(s => s.Country, opt => opt.MapFrom<BTCountryNameResolver>())
            .ForMember(d => d.RegionID, opt => opt.MapFrom(src => src.cityid))
            .ForMember(s => s.Region, opt => opt.MapFrom<BTCityNameResolver>())
            .ForMember(d => d.TripStartDate, opt => opt.MapFrom(src => src.datefrom))
            .ForMember(d => d.TripEndDate, opt => opt.MapFrom(src => src.dateto))
            .ForMember(d => d.IsLivingProvided, opt => opt.MapFrom(src => src.isliving != null ? (src.isliving.Equals("Y") ? true : false) : false))
            .ForMember(d => d.MandateValue, opt => opt.MapFrom(src => src.mandatevalue))
            .ForMember(d => d.IsTransportationNeeded, opt => opt.MapFrom(src => src.istransport != null ? src.istransport.Equals("Y") ? true : false : false))
            .ForMember(d => d.LivingStartDate, opt => opt.MapFrom(src => src.livingcheckindate != null ? (DateTime?)DateTime.ParseExact(src.livingcheckindate, StaticClass.Configuration["owsDateFormat"], System.Globalization.CultureInfo.InvariantCulture) : null))
            .ForMember(d => d.LivingEndDate, opt => opt.MapFrom(src => src.livingcheckoutdate != null ? (DateTime?)DateTime.ParseExact(src.livingcheckoutdate, StaticClass.Configuration["owsDateFormat"], System.Globalization.CultureInfo.InvariantCulture) : null))
            .ForMember(d => d.IsCarNeeded, opt => opt.MapFrom(src => src.isReplaceTicketWithCar != null ? (src.isReplaceTicketWithCar.Equals("Y") ? true : false) : false))
            .ForMember(d => d.IsVisaNeeded, opt => opt.MapFrom(src => src.isVisaNeeded != null ? src.isVisaNeeded.Equals("Y") ? true : false : false))
            .ForMember(d => d.ExtraDaysBefore, opt => opt.MapFrom(src => src.extradaysbefore))
            .ForMember(d => d.ExtraDaysAfter, opt => opt.MapFrom(src => src.extradaysafter));


            CreateMap<trainingRequestLine, BusinessTripLine>()
           .ForMember(d => d.LineID, opt => opt.MapFrom(src => src.id))
           .ForMember(d => d.CountryID, opt => opt.MapFrom(src => src.countryid))
           .ForMember(d => d.Country, opt => opt.MapFrom<TRCountryNameResolver>())
           .ForMember(d => d.RegionID, opt => opt.MapFrom(src => src.cityid))
           .ForMember(d => d.Region, opt => opt.MapFrom<TRCityNameResolver>())
           .ForMember(d => d.TripStartDate, opt => opt.MapFrom(src => src.datefrom))
           .ForMember(d => d.TripEndDate, opt => opt.MapFrom(src => src.dateto))
           .ForMember(d => d.IsLivingProvided, opt => opt.MapFrom(src => src.isliving != null ? (src.isliving.Equals("Y") ? true : false) : false))
           .ForMember(d => d.MandateValue, opt => opt.MapFrom(src => src.mandatevalue))
           .ForMember(d => d.IsTransportationNeeded, opt => opt.MapFrom(src => src.istransport != null ? (src.istransport.Equals("Y") ? true : false) : false))
           .ForMember(d => d.LivingStartDate, opt => opt.MapFrom(src => src.livingcheckindate != null ? (DateTime?)DateTime.ParseExact(src.livingcheckindate, StaticClass.Configuration["owsDateFormat"], System.Globalization.CultureInfo.InvariantCulture) : null))
           .ForMember(d => d.LivingEndDate, opt => opt.MapFrom(src => src.livingcheckoutdate != null ? (DateTime?)DateTime.ParseExact(src.livingcheckoutdate, StaticClass.Configuration["owsDateFormat"], System.Globalization.CultureInfo.InvariantCulture) : null))
           .ForMember(d => d.ExtraDaysBefore, opt => opt.MapFrom(src => src.extradaysbefore))
           .ForMember(d => d.ExtraDaysAfter, opt => opt.MapFrom(src => src.extradaysafter));

            CreateMap<overtimeRequestLine, OvertimeLine>()
           .ForMember(d => d.Day, opt => opt.MapFrom(src => src.DayNameEn))
           .ForMember(d => d.Hours, opt => opt.MapFrom(src => src.hours))
           .ForMember(d => d.Date, opt => opt.MapFrom(src => src.dateTrx));

            CreateMap<MissionCompletion, missionCompletion>()
             .ForMember(d => d.regionid, opt => opt.MapFrom(src => src.CityId))
             .ForMember(d => d.ktajobid, opt => opt.MapFrom(src => src.JobID))
             .ForMember(d => d.doctypeid, opt => opt.MapFrom(src => src.MissionTypeID))
             .ForMember(d => d.countryid, opt => opt.MapFrom(src => src.CountryId))
             .ForMember(d => d.employeeid, opt => opt.MapFrom(src => src.EmployeeID))
             .ForMember(d => d.extradayreason, opt => opt.MapFrom(src => src.EarlyDaysReason))
             .ForMember(d => d.mandatevalue, opt => opt.MapFrom(src => src.MandateValue))
             .ForMember(d => d.isFood, opt => opt.MapFrom(src => src.IsFoodProvided == true ? "Y" : "N"))
            // .ForMember(d => d.isFood, opt => opt.MapFrom(src => src.IsFoodProvided))
             .ForMember(d => d.isTransport, opt => opt.MapFrom(src => src.IsTransportationProvided == true ? "Y" : "N"))
              //.ForMember(d => d.isTransport, opt => opt.MapFrom(src => src.IsTransportationProvided == true ? "Y" : "N"))
              .ForMember(d => d.isLiving, opt => opt.MapFrom(src => src.IsAccomedatoinProvided == true ? "Y" : "N"))
             // .ForMember(d => d.isLiving, opt => opt.MapFrom(src => src.IsAccomedatoinProvided))
             .ForMember(d => d.grossamount, opt => opt.MapFrom(src => src.GrossAmount))
             .ForMember(d => d.datefrom, opt => opt.MapFrom(src => src.DateFrom))
             .ForMember(d => d.dateto, opt => opt.MapFrom(src => src.DateTo))
             //.ForMember(d => d.isLoan, opt => opt.MapFrom(src => src.IsAdvancedPaymentNeeded))
             .ForMember(d => d.isLoan, opt => opt.MapFrom(src => src.IsAdvancedPaymentNeeded == true ? "Y" : "N"))
             .ForMember(d => d.loanvalue, opt => opt.MapFrom(src => src.AdvancedPaymentTotal))
             .ForMember(d => d.earlydays, opt => opt.MapFrom(src => src.EarlyDays))
             .ForMember(d => d.fooddeductdays, opt => opt.MapFrom(src => src.FoodDeductDays))
             .ForMember(d => d.transdeductdays, opt => opt.MapFrom(src => src.TransDeductDays))
             .ForMember(d => d.livingdeductdays, opt => opt.MapFrom(src => src.LivingDeductDays))
             .ForMember(d => d.otherallowance, opt => opt.MapFrom(src => src.OtherAllowance))
             .ForMember(d => d.otherdeduction, opt => opt.MapFrom(src => src.OtherDeduction))
             .ForMember(d => d.otherdeductionreason, opt => opt.MapFrom(src => src.OtherDeductionReason))
             .ForMember(d => d.livingdeductdays, opt => opt.MapFrom(src => src.LivingDeductDays))
             .ForMember(d => d.documentno, opt => opt.MapFrom(src => src.REF_ID))
             .ForMember(d => d.grossamount, opt => opt.MapFrom(src => src.GrossAmount))

             .ForMember(dest => dest.HR_trainingrequest_ID, opt => opt.Condition((src, dest) =>
             {
                 if (src.MissionTypeID == (int)MissionType.TrainingMissionTypeID)
                 {
                     dest.HR_trainingrequest_ID = src.MissionID;
                     return true;
                 }
                 else
                     return false;

             }))

             //.ForMember(d => d.HR_trainingrequest_ID,
             // opt => opt.MapFrom
             //(src => src.MissionTypeID == (int)MissionType.TrainingMissionTypeID ? src.MissionID : 0))

             .ForMember(d => d.HR_mandaterequestmaster_ID,
              opt => opt.MapFrom
             (src => src.MissionTypeID == (int)MissionType.MandateMissionTypeID ? src.MissionID : 0))

             .ForMember(d => d.HR_overtimerequest_ID,
              opt => opt.MapFrom
             (src => src.MissionTypeID == (int)MissionType.OverTimeMissionTypeID ? src.MissionID : 0)).
             ReverseMap()
             .ForMember(d => d.CompletedDate, opt => opt.MapFrom(src => src.earlydays > 0 ? DateTime.Parse(src.dateto).AddDays(src.earlydays) : (DateTime?)null))
             .ForMember(d => d.Id, opt => opt.MapFrom(src => src.id))
             .ForMember(d => d.MissionID, opt => opt.MapFrom(src => src.HR_mandaterequestmaster_ID > 0 ? src.HR_mandaterequestmaster_ID : src.HR_overtimerequest_ID > 0 ? src.HR_overtimerequest_ID : src.HR_trainingrequest_ID > 0 ? src.HR_trainingrequest_ID : 0))
             .ForMember(d => d.IsAccomedatoinProvided, opt => opt.MapFrom(src => src.isLiving != null ? (src.isLiving.Equals("Y") ? true : false) : false))
             .ForMember(d => d.IsFoodProvided, opt => opt.MapFrom(src => src.isFood != null ? (src.isFood.Equals("Y") ? true : false) : false))
             .ForMember(d => d.IsTransportationProvided, opt => opt.MapFrom(src => src.isTransport != null ? (src.isTransport.Equals("Y") ? true : false) : false))
             .ForMember(d => d.IsAdvancedPaymentNeeded, opt => opt.MapFrom(src => src.isLoan != null ? (src.isLoan.Equals("Y") ? true : false) : false))
             .ForMember(d => d.City, opt => opt.Ignore())
             .ForMember(d => d.Country, opt => opt.Ignore());

        }

    }
}
