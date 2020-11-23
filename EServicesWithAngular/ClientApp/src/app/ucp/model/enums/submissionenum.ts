export enum SubmissionEnum {
    ProfilePicture = 1,
    Cv = 2,
    Biblography = 3,
    MajorAchievement = 4,
    ResearchPlan = 5,
    Publication=6,
    ResearchAbstract=8
}

export enum StatusEnum
{
    New = 1,//new commmet from admin
    Read = 2,// read by fellow but not done yet
    Done = 3,//done by fellow
    Changed=4//changed by fellow then will become done on the backend
}




