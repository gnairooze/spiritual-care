import { IModelBase } from '../../../models/i-model-base';

export interface IPEducation extends IModelBase {
    EducationType: string;
    Value: string;
    Comment: string;
}
