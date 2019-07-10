export interface Itask {
  UserTaskId:number;
  ParentId:number;
    ParentTask:string;
    Task:string;
    StartDate:Date;
    EndDate:Date;
    Priority:number;
  }