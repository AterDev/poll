/**
 * 议题投票选项实体类型添加时请求结构
 */
export interface PollOptionAddDto {
  /**
   * 选项描述
   */
  content: string;
  /**
   * 投票数
   */
  voteCount: number;
  pollIssueId: string;

}
