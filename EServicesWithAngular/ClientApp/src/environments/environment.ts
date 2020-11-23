// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
 //serverPath: "http://DES:8080",
  //serverPath: "http://ES:8080",
 serverPath: "http://localhost:57708",

  localization: {
    defaultLang: 'en-US',
    localStorageLangKey: 'KaCare_Lang',
  },



  file: {
    AllowedFileSize: 5,
    AllowedImageExtensions: ["jpg", "png", "gif","jpeg"],
    AllowedAttachmentExtensions: ".jpg, .png , .gif , .pdf, .doc, .docx, .jpeg",
    AllowedTranslationAttachementExtensions: ".doc,.docx",
  },

  services: {
    BaseService:"Base",
    ItAccountService: "ITAccount",
    ItResignationService: "ITResignation",
    SPSiteCreationService:"SPSiteCreation",
    TranslationService :"AdminTranslation",
    ITCareService:"ITCare",
    ConsultationService:"Consultation",
    ConsultationCompletionService:"ConsultationCompletion",
    EmailGroupService:"EmailGroup",
    ItServerAccessService: "ITServerAccess",
    SoftwareService:"Software"
   
  },

  pager: {
    pageSize: 10,
    pageLinks: 8,
    rowsPerPageOptions: [5, 10, 20]

  },



  dateFormat: {
    date: "DD/MM/YYYY",
    dateWithTime: "DD/MM/YYYY h:mm:ss A",
    apiDate: "MM/DD/YYYY",
    apiDateWithTime: "MM/DD/YYYY HH:mm",
    apiTime: "HH:mm",
    calendarDate: "dd/mm/yy",
    apiDateparm :"YYYY-MM-DD HH:mm:ss"
  },

  patterns: {
    mobilePattern: "^\\d{4,20}$",
    emailPattern: "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$",
    urlPattern: "^(http:\\/\\/www\.|https:\\/\\/www\.|http:\\/\\/|https:\\/\\/|www\.)[a-zA-Z0-9]+([\\-\\.]{1}[a-zA-Z0-9]+)*\\.[a-zA-Z]{2,5}(:[0-9]{1,5})?(\\/.*)?$",
    percentagePattern: "^\\d{0,2}(\\.\\d{0,2})?$",
    numberPattern: "^\\d{0,10}$",
    floatNumberPattern: "^\\d{0,10}(\\.\\d{0,10})?$",
    officeNnmber:"[1-9][0-9]{2}",
    englishOnly:"^[a-zA-Z0-9.@ _& ]*$"
  },
  navigation:{
    profileFellow :"http://localhost:4200/ucp/account/win-login?fellowEmail="

  },

  ConsultationDuration :{
    MaxMonthPerYear : 31,// 1 month 
    MaxDaysPerMonth : 10,
  
  },

  UniCosts : {
    KFUPM : 3000,
    KSU :2500,
    KAU :3000,

  }
};
