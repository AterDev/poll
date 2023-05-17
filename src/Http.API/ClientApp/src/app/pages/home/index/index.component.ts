import { Component, OnInit } from '@angular/core';
import { EChartsOption } from 'echarts';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  chartOption: EChartsOption = {
    xAxis: {
      type: 'category',
      data: ['2022-05-01', '2022-05-02', '2022-05-03', '2022-05-04', '2022-05-05', '2022-05-06', '2022-05-07'],
    },
    yAxis: {
      type: 'value',
    },
    series: [
      {
        // 开盘值, 收盘值, 最低值, 最高值
        data: [
          [920, 932, 901, 934],
          [930, 901, 1000, 934],
          [901, 1000, 890, 1234],
          [1000, 890, 789, 1234],
          [890, 1234, 1090, 1345],
          [1234, 1090, 1200, 1345],
          [1090, 1200, 1120, 1300],
        ],
        type: 'candlestick',
        itemStyle: {
          color: '#FD1050',
          color0: '#0CF49B',
          borderColor: '#FD1050',
          borderColor0: '#0CF49B',
        },
      },
    ],
  };

  constructor() { }

  ngOnInit(): void {
  }

}
