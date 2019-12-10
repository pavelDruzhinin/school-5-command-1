<template>
    <div>
        <v-card >
            <v-card-title>
                List of polls
                <v-spacer></v-spacer>
                <v-text-field
                        append-icon="mdi-search-web"
                        label="Search"
                        single-line
                        hide-details
                        v-model="search"
                ></v-text-field>
            </v-card-title>
            <v-data-table
                    v-model="selected"
                    :headers="headers"
                    :items="items"
                    :search="search"
                    @onRowClick="openDetail"
                    

            >
                <template v-slot:item="props" 
                 >
                    <tr>
                        <td v-for="id in id"
        :key="id">{{ props.item.botsid }}</td>
                        <td @click="goTodetail(props.item.id)" class="text-xs-right" >{{ props.item.title }}</td>
                        <td class="text-xs-right">{{ props.item.company }}</td>
                        <td class="text-xs-right">{{ props.item.userpassed }}</td>
                        <td class="text-xs-right">{{ props.item.questions_num }}</td>
                        <td class="text-xs-right">{{ props.item.createdate }}</td>
                    </tr>
                </template>
                <v-alert slot="no-results" :value="true" color="error" icon="warning">
                    Your search for "{{ search }}" found no results.
                </v-alert>
            </v-data-table>
        </v-card>
    </div>
</template>
<script>
        import axios from 'axios';
    export default {
        data() {
            return {
                selected: [],
                search: '',
                items: [],
                headers: [
                    {
                        text: 'Poll title',
                        align: 'left',
                        sortable: false,
                        value: 'name'
                    },
                    {text: 'Company', value: 'company'},
                    {text: 'Number of questions', value: 'numquest'},
                    {text: 'Polled users', value: 'userpolls'},
                    {text: 'Creation date', value: 'creatdate'},
                ],
            }
        },
        created() {
      axios.get(`https://my-json-server.typicode.com/AlexanderPanshin/dpv.school/bots`)
      .then(response=> {
        this.items= response.data;
      })
      .catch(error=> {
        window.console.log(error);
        this.errored=true;
      })

    },
    methods: {
        openDetail(a) {
                if (event.target.classList.contains('btn__content')) return;
                alert('Polls title: \n' + a.userid);
            },
    goTodetail (prodId) {
      let proId=prodId
      this.$router.push({name: 'cardchat', params: {Pid: proId}})
    }
  }
    }
</script>
