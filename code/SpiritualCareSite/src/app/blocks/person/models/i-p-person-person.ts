import { IModelBase } from '../../../models/i-model-base';

export interface IPPersonPerson extends IModelBase {
    Person_ID: number;
    ToPerson_ID: number;
    RelationType: string;
    Comment: string;
}
