import { PollType } from '../enum/poll-type.model';
import { PollOption } from '../poll-option/poll-option.model';
import { PollTag } from '../poll-tag/poll-tag.model';
import { PollCategory } from '../poll-category/poll-category.model';
/**
 * 议题投票实体类型
 */
export interface PollIssue {
  id: string;
  createdTime: Date;
  updatedTime: Date;
  /**
   * 软删除
   */
  isDeleted: boolean;
  /**
   * 议题编号
   */
  issueNo: string;
  /**
   * 议题标题
   */
  title: string;
  /**
   * 议题描述
   */
  description: string;
  pollType?: PollType | null;
  /**
   * 有效开始时间
   */
  effectiveStartDate: Date;
  /**
   * 有效结束时间
   */
  effectiveEndDate: Date;
  /**
   * 议题选项列表
   */
  options?: PollOption[];
  tags?: PollTag[] | null;
  category?: PollCategory | null;

}
