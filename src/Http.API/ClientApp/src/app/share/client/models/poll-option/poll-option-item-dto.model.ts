/**
 * 议题投票选项实体类型列表元素
 */
export interface PollOptionItemDto {
  /**
   * 选项描述
   */
  content: string;
  /**
   * 投票数
   */
  voteCount: number;
  id: string;
  createdTime: Date;
  updatedTime: Date;

}
