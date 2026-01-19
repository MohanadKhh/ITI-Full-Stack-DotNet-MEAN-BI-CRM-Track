import { ChangeDetectorRef, Component } from '@angular/core';

@Component({
  selector: 'app-slideshow',
  imports: [],
  templateUrl: './slideshow.html',
  styleUrl: './slideshow.css',
})
export class Slideshow {
  currImgSrc = "/images/1.jpg";
  imgSrcArr = ["/images/1.jpg", "/images/2.jpg", "/images/3.jpg", "/images/4.jpg", "/images/5.jpg", "/images/6.jpg", "/images/7.jpg"];
  index = 0;
  interval: any = null;
  constructor(private ref: ChangeDetectorRef){}

  nextPic() {
    if (this.index < this.imgSrcArr.length - 1)
      this.currImgSrc = this.imgSrcArr[++this.index]
  }

  prevPic() {
    if (this.index > 0)
      this.currImgSrc = this.imgSrcArr[--this.index]
  }

  startShow() {
    if (this.interval) return;

    this.interval = setInterval(() => {
      this.index = (this.index + 1) % this.imgSrcArr.length
      this.currImgSrc = this.imgSrcArr[this.index]
      this.ref.detectChanges();
    }, 2000)
  }

  stopShow() {
    clearInterval(this.interval);
    this.interval = null;
  }
}
