import { Column, Entity, OneToMany, PrimaryGeneratedColumn, ManyToOne, OneToOne } from 'typeorm';
import { Bot } from './bot';
import { User } from './user'

@Entity()
export class Question {
  @PrimaryGeneratedColumn()
  id: number;
  }