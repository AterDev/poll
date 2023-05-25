import { PollTagItemDto } from '../poll-tag/poll-tag-item-dto.model';
export interface PollTagItemDtoPageList {
  count: number;
  data?: PollTagItemDto[];
  pageIndex: number;

}
