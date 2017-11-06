import { IModelBase } from '../../../models/i-model-base';

export interface IPPersonMeeting extends IModelBase {
    Person_ID: number;
    Church: string;
    MeetingName: string;
    Comment: string;
}
