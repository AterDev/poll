import { PollCategoryItemDto } from '../poll-category/poll-category-item-dto.model';
export interface PollCategoryItemDtoPageList {
  count: number;
  data?: PollCategoryItemDto[];
  pageIndex: number;

}
