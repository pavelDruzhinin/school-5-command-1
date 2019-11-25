<template>
  <v-card>
    <v-card-title>
      List of polls
      <v-spacer></v-spacer>
      <v-text-field
        v-model="search"
        append-icon=""
        label="Search"
        single-line
        hide-details
      ></v-text-field>
    </v-card-title>
    <v-data-table
      :headers="headers"
      :items="desserts"
      :search="search"
    ></v-data-table>
  </v-card>
</template>

<script>
  export default {
    data () {
      return {
        search: '',
        headers: [
          {
            text: 'Poll Name',
            align: 'left',
            sortable: false,
            value: 'name',
          },
          { text: 'Users in the polls', value: 'userpolls' },
          { text: 'Number of questions', value: 'numquest' },
          { text: 'Creation date', value: 'creatdate' },
        ],
        desserts: [
          {
            name: 'Motor mechanic',
            userpolls: 159,
            numquest: 7,
            creatdate: '02.10.2015',
          },
          {
            name: 'Obstetrician',
            userpolls: 237,
            numquest: 12,
            creatdate: '22.09.2017',
          },
          {
            name: 'Auditor',
            userpolls: 262,
            numquest: 10,
            creatdate: '28.12.2016',
          },
          {
            name: 'Botanist',
            userpolls: 305,
            numquest: 3,
            creatdate: '16.12.2019',
          },
          {
            name: 'Bookkeeper',
            userpolls: 356,
            numquest: 15,
            creatdate: '15.04.2016',
          },
          {
            name: 'Plumber',
            userpolls: 375,
            numquest: 26,
            creatdate: '19.12.2017',
          },
          {
            name: 'Geneticist',
            userpolls: 392,
            numquest: 44,
            creatdate: '10.11.2016',
          },
          {
            name: 'Railwayman',
            userpolls: 408,
            numquest: 35,
            creatdate: '30.11.2015',
          },
          {
            name: 'Merchant',
            userpolls: 452,
            numquest: 17,
            creatdate: '27.03.2017',
          },
          {
            name: 'Astronaut',
            userpolls: 518,
            numquest: 18,
            creatdate: '29.03.2016',
          },
        ],
      }
    },
  }
</script>