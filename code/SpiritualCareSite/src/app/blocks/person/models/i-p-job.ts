import { IModelBase } from '../../../models/i-model-base';

export interface IPJob extends IModelBase {
    Profession: string;
    JobTitle: string;
    Employer: string;
    Comment: string;
}
