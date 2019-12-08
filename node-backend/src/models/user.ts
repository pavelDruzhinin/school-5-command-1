import { Column, Entity, OneToMany, PrimaryGeneratedColumn } from 'typeorm';
import { Bot } from './bot';

@Entity()
export class User {
  @PrimaryGeneratedColumn()
  id: number;

  @Column({ unique: true })
  oktaUserId: string;

  @OneToMany(() => Bot, bot => bot.creator)
  bots: Promise<Array<Bot>>;

}