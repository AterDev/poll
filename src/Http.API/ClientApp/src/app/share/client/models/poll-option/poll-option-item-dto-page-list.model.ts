import { PollOptionItemDto } from '../poll-option/poll-option-item-dto.model';
export interface PollOptionItemDtoPageList {
  count: number;
  data?: PollOptionItemDto[];
  pageIndex: number;

}
