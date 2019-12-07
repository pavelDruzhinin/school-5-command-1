import { Column, Entity, OneToMany, PrimaryGeneratedColumn } from 'typeorm';
import { Bot } from './bot';
import { Answer } from './answer';

@Entity()
export class User {
  @PrimaryGeneratedColumn()
  id: number;

  @Column({ unique: true })
  oktaUserId: string;

  @OneToMany(() => Bot, bot => bot.creator)
  bots: Promise<Array<Bot>>;

  @OneToMany(() => Answer, answer => answer.creator)
  answers: Promise<Array<Answer>>;
}