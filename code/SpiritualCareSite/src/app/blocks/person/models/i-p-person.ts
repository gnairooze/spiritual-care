import { IModelBase } from '../../../models/i-model-base';

export interface IPPerson extends IModelBase {
    Title: string;
    FirstName: string;
    MiddleName: string;
    LastName: string;
    FamilyName: string;
    FamilyRole: string;
    Photo: File;
    BirthDate: Date;
    IsMale: Boolean;
    NationalID: string;
    SocialStatus: string;
    Comment: string;
    Church: string;
    Diocese: string;
    ConfessionFather: string;
    ServantInChurchService: string;
    IsLordBrother: Boolean;
}
