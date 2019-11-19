export interface BaseModel{
    guid?: string;
    error?: string;
}

export interface AuthDataModel {
    login: string;
    password: string;
}

export interface UserModel extends BaseModel{
    id: number;
    type: number;
    login: string;
    mail: string;
    name: string;
}

export interface TaskModel extends BaseModel{
    nid?: number;
    sid?: string;
    ntype?: number;
    stype?: string;
    nstate?: number;
    sstate?: string;
    usrCreate?: number;
    usrCreateName?: string;
    usrRealize?: number;
    usrRealizeName?: string;
    title?: string;
    content?: string;
    description?: string;
    dateCreate?: Date;
    dateRealize?: Date;
}